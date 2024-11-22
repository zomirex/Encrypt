using Encrypt;
using System.ComponentModel.DataAnnotations;
//Encoder ne = new Encoder();
//ne.EncodeNumber1("amir", "sama");
//Decoder de = new Decoder();
//int codenumber = ne.EncodeNumber1("amir", "sama");
string text = "SAlaM Man ALAn DAr KhonaToonaM";
//string encodedtext = ne.encoder(text, codenumber);
//string decodetext =de.decoder(encodedtext, codenumber);

//string hash = ne.GetHashString(text);
//Console.WriteLine(ne.GetHashString(text));
//Console.WriteLine(de.GetHashString(decodetext));
//Console.WriteLine(de.CheckHash(hash));



string  path1 = @"C:\Users\Pcmod\Desktop\messagedecode.txt",path2 = @"C:\Users\Pcmod\Desktop\messagedecode2.ini", path3 = @"C:\Users\Pcmod\Desktop\messagede2.csv";
//TXTManager txt = new TXTManager();
//txt.FileWriter(path1, encodedtext);
//CSVManager csv = new CSVManager();
//csv.FileWriter(path3, encodedtext);
//INIManager ini = new INIManager(path2);
//ini.FileWriter("message", encodedtext);

//Console.WriteLine(codenumber);
//Console.WriteLine("////////////////////////////////////////////////////////////");

//Console.WriteLine(txt.Filereder(path1));

//Console.WriteLine(csv.Filereder(path3));

//Console.WriteLine(ini.Filereder("message"));
//Console.WriteLine("////////////////////////////////////////////////////////////");
//Console.WriteLine(text );

//Console.WriteLine(de.decoder(txt.Filereder(path1),codenumber));
//Console.WriteLine(de.decoder(csv.Filereder(path3), codenumber+1));
//Console.WriteLine(de.decoder(ini.Filereder("message"), codenumber+3));

//Console.WriteLine("////////////////////////////////////////////////////////////");
TXTManager g = new TXTManager();
int a = g.codedNumber1("AreF","SommaYeh");
Console.WriteLine(a%52);
Console.WriteLine(g.encoder(text,a));
Console.WriteLine(text);
g.FileWriter(path1, g.encoder(text,a));
Console.WriteLine(  g.decoder( g.Filereder(path1),a));
