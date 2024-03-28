using CSScriptLib;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace RabbitMqSim
{
    public class SimulaterBooter
    {
        public string scriptStroageString { get; private set; }

        private readonly string defaultScriptDir = "scripts";
        public string ScriptDir => Path.Combine(Environment.CurrentDirectory, defaultScriptDir);

        public string ScriptDllFile => Path.Combine(Environment.CurrentDirectory, "Scripts.dll");

        private IMessageHandler? messageHandler;
        //private UnloadableAssembly? asm;
        //private WeakReference? assemblyHost;

        private RichTextBox richTextBox { get; set; }
        private RichTextBox richTextBox_Received { get; set; }
        public void Start(RichTextBox richTextBoxAll, RichTextBox richTextBoxReceived)
        {
            try
            {
                richTextBox = richTextBoxAll;
                richTextBox_Received = richTextBoxReceived;
                LoadLocalScripts(ScriptDir);
                LoadImpl();
            }
            catch (Exception ex)
            {
                HandleLog(ex.Message);
            }
        }

        public void LoadLocalScripts(string scriptsDirectory)
        {
            Dictionary<string, string> scriptDir = new();
            scriptStroageString = string.Empty;
            try
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, scriptsDirectory);
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                List<string> referenceList = new();
                List<string> codeList = new();
                Directory.GetFiles(filePath, "*.cs").ToList().ForEach(p =>
                {
                    bool readUsing = true;
                    foreach (var line in File.ReadLines(p))
                    {
                        if ((line.TrimStart().StartsWith("using ") || line.TrimStart().StartsWith("global using ")) && readUsing)
                        {
                            if (!referenceList.Contains(line))
                                referenceList.Add(line);
                        }
                        else
                        {
                            if (readUsing)
                            {
                                if (!string.IsNullOrEmpty(line.Trim()))
                                {
                                    readUsing = false;
                                }
                            }
                            codeList.Add(line);
                        }

                    }
                });

                if (referenceList.Count != 0 || codeList.Count != 0)
                {
                    scriptStroageString = String.Join("\r\n", referenceList);
                    scriptStroageString += "\r\n";
                    scriptStroageString += String.Join("\r\n", codeList);
                }


            }
            catch (Exception ex)
            {
            }
        }



        public void LoadImpl()
        {
            var path=CSScript.Evaluator
                    .ReferenceAssemblyOf<IMessageHandler>()
                    .CompileAssemblyFromCode(scriptStroageString, ScriptDllFile);
            //asm = new UnloadableAssembly();
            //assemblyHost = new WeakReference(asm);
            AssemblyLoadContext asm = new AssemblyLoadContext("Base");
            using (FileStream fs = new FileStream(ScriptDllFile, FileMode.Open, FileAccess.Read))
            {
                messageHandler = (IMessageHandler)asm.LoadFromStream(fs)
                                    .CreateInstance("css_root+RabbitMqSimScript"); // or `CreateInstance("css_root+Script")`

                messageHandler.LogHandler += HandleLog;
                messageHandler.ReceivedLogHandler += MessageHandler_ReceivedLogHandler;
                messageHandler.Start();
            }
               


        }

        private void MessageHandler_ReceivedLogHandler(string msg)
        {
            Action action = () =>
            {
                this.richTextBox_Received.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
            };


            if (this.richTextBox_Received.InvokeRequired)
            {
                this.richTextBox_Received.Invoke(action);
            }
            else
            {
                this.richTextBox_Received.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
            }

        }

        private void HandleLog(string msg)
        {
            Action action = () =>
            {
                this.richTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
            };
            if (this.richTextBox.InvokeRequired)
            {
                this.richTextBox.Invoke(action);
            }
            else
            {
                this.richTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}\r\n");
            }
        }

        public void UnloadImpl()
        {
            if (messageHandler == null) return;
            messageHandler.LogHandler -= HandleLog;
            messageHandler.ReceivedLogHandler -= MessageHandler_ReceivedLogHandler;
            messageHandler.Close();
            messageHandler.Dispose();
            messageHandler = null;
            //asm.Unload();
            //for (int i = 0; assemblyHost.IsAlive && (i < 10); i++)
            //{
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //Console.WriteLine($"Unload success: {!assemblyHost.IsAlive}");

            try
            {
                File.Delete(ScriptDllFile); // prove that the assembly is unloaded
            }
            catch (Exception)
            {

            }
        }

        public void ReStart(RichTextBox richTextBox1, RichTextBox richTextBoxReceived)
        {
            UnloadImpl();
            Start(richTextBox1,richTextBoxReceived);
        }

        internal void Stop()
        {
            UnloadImpl();
        }

        internal void Send(string text)
        {
            messageHandler?.Send(text);
        }

        class UnloadableAssembly : AssemblyLoadContext
        {
            public UnloadableAssembly(string name = null) : base(name ?? Guid.NewGuid().ToString(), isCollectible: true)
                => this.Unloading += x => Console.WriteLine("Unloading " + this.Name);
        }

    }
}
