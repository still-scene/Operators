using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class FilesInFolder : Instance<FilesInFolder>
    {
        [Output(Guid = "99bd5b48-7a28-44a7-91e4-98b33cfda20f")]
        public readonly Slot<List<string>> Files = new Slot<List<string>>();


        public FilesInFolder()
        {
            Files.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var folderPath = Folder.GetValue(context);
            var filter = Filter.GetValue(context);
            var filePaths = Directory.Exists(folderPath) 
                              ? Directory.GetFiles(folderPath).ToList() 
                              : new List<string>();

            
            Files.Value = string.IsNullOrEmpty(Filter.Value) 
                              ? filePaths 
                              : filePaths.FindAll(filepath => filepath.Contains(filter)).ToList();
        }

        [Input(Guid = "ca9778e7-072c-4304-9043-eeb2dc4ca5d7")]
        public readonly InputSlot<string> Folder = new InputSlot<string>(".");
        
        [Input(Guid = "8B746651-16A5-4274-85DB-0168D30C86B2")]
        public readonly InputSlot<string> Filter = new InputSlot<string>("*.png");
    }
}