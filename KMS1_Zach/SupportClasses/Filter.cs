using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace KMS1_Zach.SupportClasses
{
    public class Filter
    {
        public static string testLine = "\"101\" 2 \"00000384\" \"SZ1238:szfEDV:a6b4ba21ba54f6bde411900bb31b55df\"";


        public async Task<string> filterString(string content)
        {


           // List<string> filtered = new List<string>();

            //foreach (var s in content)
            //{
                content = await new Filter().removeApostrophes(content);
                content = await new Filter().removeCharacters(content);
                content = await new Filter().removeStringSegment(content);
                content = await new Filter().moveStringSegment(content);

                //filtered.Add(content);
            //}
            
            return content;
        }

        public async Task<string> removeApostrophes(string s)
        {
            await Task.Run(() =>
            {
                s = s.Replace("\"", "");                
            });
            return s;
        }

        public async Task<string> removeCharacters(string s)
        {
            string[] charsToRemove = { "s", "z", "f", "e", "d", "v", ":" , };

            await Task.Run(() =>
            {
                foreach (var c in charsToRemove)
                {
                    s = s.Replace(c, "");
                }
            });
            return s;

        }

        public async Task<string> moveStringSegment(string s)
        {
            await Task.Run(() =>
            {
                string moveSegment = s.Substring(0, 4);
                s = s.Remove(0, 4);
                s = s + moveSegment;
                s = s.Replace(" ", "");
                
            });
            return s;
        }

        public async Task<string> removeStringSegment(string s)
        {
            await Task.Run(() =>
            {
                s = s.Remove(0, 15);
            });
            return s;
        }

        public async Task<string> splitString(string s)
        {
            return null;
        }

    }
}
