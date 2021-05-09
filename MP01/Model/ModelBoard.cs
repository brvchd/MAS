using MP01.Exceptions;

namespace MP01
{
    public class ModelBoard
    {
        private string _model;
        public string Model
        {
            get => _model;
            set => _model = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationExceptions("Invalid model");
        }
        private string _boardVersion;
        public string BoardVersion
        {
            get => _boardVersion;
            set => _boardVersion = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationExceptions("Invalid board version");
        }
        private string _localset;
        public string LocalSet
        {
            get => _localset;
            set => _localset = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationExceptions("Invalid local set");
        }

        public ModelBoard(string model, string boardVersion, string localSet)
        {
            Model = model;
            BoardVersion = boardVersion;
            LocalSet = localSet;
        }
    }
}