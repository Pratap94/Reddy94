using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace New_logic
{
    public class Program
    {
        //PrintProcess Starts here-----------
        static String filePath = "C:/Users/PR073333/Desktop/C#/patternholdBoolactive.txt";
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"\\ipfactory\FT_SourceCode\Solution_Test\WIN64\CSHARP_X64\Inpatient Pharmacy\", "*.cs", SearchOption.AllDirectories);
            string asr = "";



            foreach (string file in files)
            {
                using (StreamReader n = new StreamReader(file))
                {
                    asr = n.ReadToEnd();
                }
                string pat = "ActiveSheet.SortRows";
                Regex rgx = new Regex(pat);
                Match match = rgx.Match(asr);
                if (match.Success)
                {
                    Console.WriteLine("Folder: " + Path.GetFileName(Path.GetDirectoryName(file)));
                    Console.WriteLine("File: " + Path.GetFileName(file));



                    File.AppendAllText(filePath, "Folder: " + Path.GetFileName(Path.GetDirectoryName(file)) + Environment.NewLine);
                    File.AppendAllText(filePath, "File: " + Path.GetFileName(file) + Environment.NewLine);
                    readfile.Read(file);
                }
                else
                {
                    // Console.WriteLine("file dont have the patt");
                }
            }
        }
        public class readfile
        {

            public static void Read(string file)
            {
                //find f = new find();
                //f.createfile();

                using (StreamReader x = new StreamReader(file))
                {
                    string s = " ";
                    int i = 0;

                    while ((s = x.ReadLine()) != null)
                    {
                        i++;
                        //find.find_criter(s, i);

                        //find fe = new find();
                        //fe.createfile();
                        find.find_method(s, i, file, x);
                    }
                }
            }
            //readfile c = new readfile();



        }



        class find
        {
            public static void find_method(string f, int i, string file, StreamReader x)
            {



                string astr = string.Empty;
                List<string> sub = new List<string>();

                var pattern = @"\b(public|private|internal|protected)\s*" + @"\b(static|virtual|abstract)?\s*[a-zA-Z_]*(?<method>\s[a-zA-Z_]+\s*)" + @"\((([a-zA-Z_\[\]\<\>]*\s*[a-zA-Z_]*\s*)[,]?\s*)+\)";   //searchString is passed in
                Regex rgx = new Regex(pattern);
                using (StreamReader n = new StreamReader(file))
                {
                    astr = n.ReadToEnd();
                }



                Match match = rgx.Match(f);
                string q = " ";

                MatchCollection matches = rgx.Matches(astr);
                //Console.WriteLine(x.ReadLine());
                if (match.Success)
                {
                    if (matches.Count > 0)
                    {
                        //  Console.WriteLine(match);
                        for (int j = 1; j < matches.Count; j++)
                        {
                            //Console.WriteLine("------------------------------------------------------------");
                            while ((q = (x.ReadLine()).Trim()) != (matches[j].Value))
                            {
                                if (q == null)
                                {
                                    break;
                                }
                                else
                                {
                                    // Console.WriteLine(matches[j].Value);



                                    sub.Add(q);



                                    //  find_Object(q, file, i, x,matches);
                                }
                            }
                            // sub.Add(null);
                            foreach (string n in sub)
                            {
                                i++;
                       
                                Newfind2(sub, n, i, file);
                            }
                            i++;
                            // Console.WriteLine("------------------------------------------------------------");
                            sub.Clear();
                        }




                        // x.Close();
                    }



                }



                else
                {



                }




            }

            public static void Newfind2(List<string> sub, string n, int i, string file)
            {
                var pattern_bool = "Boolean.TryParse";
                var pattern_arg = @"(\b(\w*out \w*)\b)";
                var pattern_if = "if[(]out";



                Regex rgx_if = new Regex(pattern_if);
                Regex rgx_bool = new Regex(pattern_bool);
                Regex rgx_arg = new Regex(pattern_arg);



                Match match_bool = rgx_bool.Match(n);
                Match match_if = rgx_if.Match(n);
                Match match_arg = rgx_arg.Match(n);






                if (match_bool.Success)
                {

                    int temp = 0;
                    // Console.WriteLine(n);

                    if (match_arg.Success)
                    {
                        //Console.WriteLine(match_arg);
                        foreach (string m in sub)
                        {
                            if (match_if.Success)
                            {
                                temp = 1;
                                // Console.WriteLine("all good");
                            }

                        }
                        if (temp == 1)
                        {



                        }
                        else
                        {

                            //  Console.SetOut(writer);
                            //Console.WriteLine(match_obj);
                            //Console.WriteLine(" File: " + file + ",\n Line: " + i);

                            Console.WriteLine(" Line  " + i + " : " + match_bool);
                           
                            String s1 = Path.GetFileName(Path.GetDirectoryName(file));
                            String s2 = Path.GetFileName(file);
                         
                            File.AppendAllText(filePath, " Line  " + i + " : " + match_bool + Environment.NewLine);
                          
                        }

                    }





                }

            }

            //    writer.Close();
            //   ostrm.Close();
        }
    }
}
