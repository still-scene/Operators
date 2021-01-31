using System.Text;
using System.Text.RegularExpressions;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7baaa83d_5c09_42a0_b7bc_35dbcfa5156d
{
    public class TextFragment : Instance<TextFragment>
    {
        [Output(Guid = "62368C06-7815-47BC-9B0D-3024A2907E01")]
        public readonly Slot<string> Fragments = new Slot<string>();

        public TextFragment()
        {
            Fragments.UpdateAction = Update;
        }

        private enum EntityTypes
        {
            Characters = 0,
            Words,
            Lines,
            Sentences,
        }

        private EntityTypes _splitInto;

        private void Update(EvaluationContext context)
        {
            if (InputText.DirtyFlag.IsDirty || SplitInto.DirtyFlag.IsDirty)
            {
                _splitInto = (EntityTypes)SplitInto.GetValue(context);
                var inputText = InputText.GetValue(context);

                switch (_splitInto)
                {
                    case EntityTypes.Characters:
                        _chunks = new Regex("(.)").Split(inputText);
                        _delimiter = "";
                        break;

                    case EntityTypes.Words:
                        _chunks = new Regex("[\\s\\.\\;\\,()`:]+").Split(inputText);
                        _delimiter = " ";
                        break;

                    case EntityTypes.Lines:
                        _chunks = new Regex("\\r+\\s*").Split(inputText);
                        _delimiter = "\n";
                        break;

                    case EntityTypes.Sentences:
                        _chunks = new Regex("\\.[\\s\\.]*").Split(inputText);
                        _delimiter = ". ";
                        break;
                    default:
                        _chunks = new string[0];
                        break;
                }

                _numberOfChunks = _chunks.Length > 0 && string.IsNullOrEmpty(_chunks[_chunks.Length - 1])
                                      ? _chunks.Length - 1
                                      : _chunks.Length;
                //_lastFragment = "";
            }

            var fragmentStart = FragmentStart.GetValue(context);
            var fragmentCount = FragmentCount.GetValue(context);
            if (_splitInto == EntityTypes.Characters)
                fragmentCount *= 2;

            Fragments.Value = GetFragment(fragmentStart, fragmentCount);
        }

        private string GetFragment(int startFragment, int fragmentCount)
        {
            var d = "";
            if (fragmentCount <= 0 || _numberOfChunks == 0)
                return "";

            var sb = new StringBuilder();
            for (var index = 0;
                 index < fragmentCount;
                 index++)
            {
                var moduloIndex = (startFragment + index) % _numberOfChunks;
                if (moduloIndex < 0)
                    moduloIndex += _numberOfChunks;

                sb.Append(d);
                sb.Append(_chunks[moduloIndex]);
                d = _delimiter;
            }

            return sb.ToString();
        }

        
        private int _numberOfChunks;
        private string[] _chunks;
        private string _delimiter;
        
        [Input(Guid = "05d7962b-a02e-4ab5-9927-865375348ccd")]
        public readonly InputSlot<string> InputText = new InputSlot<string>("Line\nLine");

        [Input(Guid = "5D7184F6-CF46-4CB0-B29F-B3C52B34B634", MappedType = typeof(EntityTypes))]
        public readonly InputSlot<int> SplitInto = new InputSlot<int>();


        [Input(Guid = "9CB908AD-0800-4B88-B256-C6CC2B84AB6C")]
        public readonly InputSlot<int> FragmentStart = new InputSlot<int>();

        [Input(Guid = "7520DB6D-7855-40E1-BB81-EAD290815435")]
        public readonly InputSlot<int> FragmentCount = new InputSlot<int>();
    }
}
