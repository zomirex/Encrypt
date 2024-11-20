using Encrypt;

int codenumber = Encrypted.EncodeNumber1("amir", "sama");
string text = "salam khoobi chetori";
string encodedtext = Encrypted.Encoder(text, codenumber);
string path = @"C:\Users\Pcmod\Desktop\message.txt", path1 = @"C:\Users\Pcmod\Desktop\messagedecode.txt",path2 = @"C:\Users\Pcmod\Desktop\messagedecode2.ini", path4 = @"C:\Users\Pcmod\Desktop\messagede2.csv";
//Console.WriteLine(codenumber);
//Console.WriteLine();
//Console.WriteLine(encodedtext);
//Console.WriteLine(text);

//Console.WriteLine();
//Console.WriteLine();

string decodedtext = Encrypted.Decoder(encodedtext, codenumber);
//Console.WriteLine(decodedtext);
TXTManager fileManager = new TXTManager();
fileManager.FileWriter(path, encodedtext);
Console.WriteLine( Encrypted.Decoder(fileManager.Filereder(path), codenumber));
fileManager.FileWriter(path1, Encrypted.Decoder(fileManager.Filereder(path), codenumber));


Console.WriteLine(Encrypted.EncodeNumber1("amir", "sama")%26);
Console.WriteLine(Encrypted.EncodeNumber2("amir", "sama")%26);

INIManager iniManager = new INIManager(path2);
iniManager.FileWriter("message1", encodedtext);
Console.WriteLine(Encrypted.Decoder(iniManager.Filereder("message1"),15));

CSVManager csvManager = new CSVManager();
csvManager.FileWriter(path4, encodedtext);
Console.WriteLine(Encrypted.Decoder(csvManager.Filereder(path4), 20));

