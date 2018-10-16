using System.Collections.Generic;

namespace Cake.PlasticSCM.Merge
{
    public class PlasticSCMDirConflict
    {
        private static readonly IDictionary<string, ConflictTypes> ConflictTypeMap = new Dictionary<string, ConflictTypes>()
        {
            {"ADD_MV", ConflictTypes.AddMove},
            {"CHG_RM", ConflictTypes.ChangeRemove},
            {"CYCLE", ConflictTypes.CycleMove},
            {"RM_CHG", ConflictTypes.RemoveChange},
            {"RM_MV", ConflictTypes.RemoveMove},    
            {"DIV_MV", ConflictTypes.DivergentMove},
            {"EVIL", ConflictTypes.EvilTwin},
            {"TWICE", ConflictTypes.LoadedTwice},
            {"MV_ADD", ConflictTypes.MoveAdd},
            {"MV_RM", ConflictTypes.MoveRemove},

        };

        private static readonly IDictionary<string, OperationTypes> OperationTypeMap = new Dictionary<string, OperationTypes>()
        {
            {"CHG", OperationTypes.Change},
            {"MV", OperationTypes.Move},
            {"RM", OperationTypes.Remove},
            {"ADD", OperationTypes.Add},
        };


        public enum ConflictTypes
        {
            Unknown,
            AddMove,
            ChangeRemove,
            CycleMove,
            RemoveChange,
            RemoveMove,
            DivergentMove,
            EvilTwin,
            LoadedTwice,
            MoveAdd,
            MoveRemove
        }

        public enum OperationTypes
        {
            Unknown,
            Move,
            Change,
            Remove,
            Add
        }

        public ConflictTypes Type { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string SourceOperationDescription { get; set; }
        public string DestinationOperationDescription { get; set; }
        public int SourceItemId { get; set; }
        public bool IsDirectory { get; set; }   
        public OperationTypes SourceOperation { get; set; }
        public string SourcePath { get; set; }
        public OperationTypes DestinationOperation { get; set; }
        public string DestinationPath { get; set; }

        public static PlasticSCMDirConflict FromStringValues(string type, string description, string message,
            string sourceOperationDescription, string destinationOperationDescription,
            string sourceItemId, string isDirectory, string sourceOperation, string sourcePath, string destinationOperation,    
            string destinationPath)
        {
            PlasticSCMDirConflict result = new PlasticSCMDirConflict
            {
                Type = ConflictTypeMap.TryGetValue(type, out var typeValue) ? typeValue : ConflictTypes.Unknown,
                Description = description,
                Message = message,
                SourceOperationDescription = sourceOperationDescription,
                DestinationOperationDescription = destinationOperationDescription,
                SourceItemId = int.Parse(sourceItemId),
                IsDirectory = isDirectory == "TRUE",
                SourceOperation = OperationTypeMap.TryGetValue(sourceOperation, out var operationValue)
                    ? operationValue
                    : OperationTypes.Unknown,
                SourcePath = sourcePath,
                DestinationOperation = OperationTypeMap.TryGetValue(destinationOperation, out operationValue)
                    ? operationValue
                    : OperationTypes.Unknown
            };

            ;
            result.DestinationPath = destinationPath;



            return result;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Description)}: {Description}, {nameof(SourceItemId)}: {SourceItemId}, {nameof(IsDirectory)}: {IsDirectory}, {nameof(SourceOperation)}: {SourceOperation}, {nameof(SourcePath)}: {SourcePath}, {nameof(DestinationOperation)}: {DestinationOperation}, {nameof(DestinationPath)}: {DestinationPath}";
        }
    }
}
