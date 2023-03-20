
using System.Collections;
using System.Text;

Console.WriteLine("==========================================================================");
Console.WriteLine("Boas-Vindas ao ALL Concatenador RS Saúde");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");

//string[] Scopes = { DriveService.Scope.Drive };

//string ApplicationName = "concatenador-rssaude";

DateTime currentDay = DateTime.Now;
var data = currentDay.AddDays(-1);

string formatada = string.Format("{0: yyyy_MMdd}", data).Trim();



string currentFolder = Directory.GetCurrentDirectory();
//Path.Combine(Environment.CurrentDirectory);

//string aConcatenar = Path.Combine(currentFolder, @"ArquivosAqui\");

Console.WriteLine($"Current folder:{currentFolder}");


string pastaGeral = Path.Combine(currentFolder, formatada);


Console.WriteLine($"Pasta Geral:{pastaGeral}");

//string fullPathConcatenado = Path.Combine(Environment.CurrentDirectory, @$"Concatenado\");

string pastaConcatenado = Path.Combine(currentFolder, @$"{pastaGeral}\{formatada} concatenado\");



//string relArquivosAqui = Path.GetRelativePath(currentFolder, aConcatenar);
//string relClientSecrets = Path.GetRelativePath(currentFolder, "clientSecrets");
//string relConcatenado = Path.GetRelativePath(currentFolder, fullPathConcatenado);


string relPastaConcat = Path.GetRelativePath(currentFolder, pastaConcatenado);
string relPastaGeral = Path.GetRelativePath(currentFolder, pastaGeral);
Console.WriteLine($"Caminho RELATIVO da pasta geral: {relPastaGeral}");
string arquivoConcatenado = Path.Combine(@$"{formatada} concatenado\{formatada} concatenado.txt");
string relArquivoConcat = Path.GetRelativePath(currentFolder, arquivoConcatenado);

//Console.WriteLine(relClientSecrets);

string[] textArray = Directory.GetFiles(currentFolder, "*.txt", SearchOption.TopDirectoryOnly);
string[] textArray2 = Directory.GetFiles(currentFolder, "*.txt", SearchOption.TopDirectoryOnly);
//string[] clientSecretsArray = Directory.GetFiles(relClientSecrets, "*.json", SearchOption.TopDirectoryOnly);

Console.WriteLine("Tentando criar  as pastas");

var titularesArray = new ArrayList();

var dependentesArray = new ArrayList();


var bradescoArray = new ArrayList();

var bradescoDepArray = new ArrayList();

var danamedArray = new ArrayList();

var danaDepArray = new ArrayList();


//Encoding iso = Encoding.GetEncoding("iso-8859-1");

//Encoding iso = Encoding.Default;

string dados;

for (int i = 0; i < textArray.Length; i++)
{
    //Console.WriteLine(textArray[i]);
    // Console.WriteLine(Path.GetFileName(textArray[i]));

    if (Path.GetFileName(textArray[i]).StartsWith("BRADESCO-") || Path.GetFileName(textArray[i]).StartsWith("DANAMED-"))
    {
        // Console.WriteLine("Inserindo arquivos Bradesco em um Array");
        titularesArray.Add(textArray[i]);
    }

    else if (Path.GetFileName(textArray[i]).StartsWith("BRADESCODEP-") || Path.GetFileName(textArray[i]).StartsWith("DANADEP-"))
    {
        // Console.WriteLine("Inserindo arquivos BradescoDep em um Array");
        dependentesArray.Add(textArray[i]);
    }

}

for (int i = 0; i < textArray2.Length; i++)
{


    if ((Path.GetFileName(textArray2[i]).StartsWith("BRADESCO-")))
    {
        bradescoArray.Add(textArray2[i]);
    }

    else if ((Path.GetFileName(textArray2[i]).StartsWith("BRADESCODEP-")))
    {
        bradescoDepArray.Add(textArray2[i]);
    }
    else if ((Path.GetFileName(textArray2[i]).StartsWith("DANAMED-")))
    {
        danamedArray.Add(textArray2[i]);
    }

    else if (Path.GetFileName(textArray2[i]).StartsWith("DANADEP-"))
    {
        danaDepArray.Add(textArray2[i]);
    }
}



Console.WriteLine($"Total de arquivos de titulares:{titularesArray.Count}");
Console.WriteLine($"Total de arquivos de dependentes:{dependentesArray.Count}");


Directory.CreateDirectory(relPastaGeral);
int countTitulares = 0;
//=================== CRIANDO PASTAS ====================================================


Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} ALL_TITULARES_concatenado\");

Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} ALL_DEPENDENTES_concatenado\");

Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} BRADESCO_concatenado\");

Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} BRADESCODEP_concatenado\");

Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} DANAMED_concatenado\");

Directory.CreateDirectory(@$"{relPastaGeral}\{formatada} DANADEP_concatenado\");

//======================================================================================================

//==================================== ESCREVENDO O CONCATENADO ========================================

foreach (var arr in titularesArray)


{
    countTitulares++;
    using (StreamReader sr = new StreamReader((string)arr, Encoding.Default))
    {
        Console.WriteLine($"Lendo os arquivos:{arr}");
        while ((dados = sr.ReadLine()) != null)
        {

            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} ALL_TITULARES_concatenado\{formatada} ALL_TITULARES_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");

            }
        }

    }
    Console.WriteLine(countTitulares);
}

Console.WriteLine("Aguarde...");

Console.WriteLine("");



foreach (var arr in dependentesArray)

{

    using (StreamReader sr = new StreamReader((string)arr,  Encoding.Default))
    {
        Console.WriteLine($"Lendo os arquivos: {arr}");
        while ((dados = sr.ReadLine()) != null)
        {

            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} ALL_DEPENDENTES_concatenado\{formatada} ALL_DEPENDENTES_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");
            }
        }

    }

}

Console.WriteLine("Aguarde...");

Console.WriteLine("");


foreach (var file in bradescoArray)
{

    Console.WriteLine($"Lendo os arquivos:{Path.GetFileName((string?)file)} ");
    using (StreamReader sr = new StreamReader((string)file, Encoding.Default))
    {
        while ((dados = sr.ReadLine()) != null)
        {

            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} BRADESCO_concatenado\{formatada} BRADESCO_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");

            }
            //using (StreamWriter sw = File.AppendText(@$"{relPastaGeral}\{formatada} BRADESCO_concatenado\{formatada} BRADESCO_concatenado.txt"))
            //{
            //    sw.Write($"{dados}\n");

            //}
        }

    }
}

Console.WriteLine("Aguarde...");
foreach (var file in bradescoDepArray)
{
    using (StreamReader sr = new StreamReader((string)file, Encoding.Default))
    {
        Console.WriteLine($"Lendo os arquivos:{Path.GetFileName((string?)file)} ");

        while ((dados = sr.ReadLine()) != null)
        {

            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} BRADESCODEP_concatenado\{formatada} BRADESCODEP_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");

            }
            //using (StreamWriter sw = File.AppendText(@$"{relPastaGeral}\{formatada} BRADESCODEP_concatenado\{formatada} BRADESCODEP_concatenado.txt"))
            //{
            //    sw.Write($"{dados}\n");

            //}
        }

    }
}


foreach (var file in danamedArray)
{
    using (StreamReader sr = new StreamReader((string)file, Encoding.Default))
    {
        Console.WriteLine($"Lendo os arquivos:{Path.GetFileName((string?)file)} ");

        while ((dados = sr.ReadLine()) != null)
        {


            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} DANAMED_concatenado\{formatada} DANAMED_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");

            }

            //using (StreamWriter sw = File.AppendText(@$"{relPastaGeral}\{formatada} DANAMED_concatenado\{formatada} DANAMED_concatenado.txt"))
            //{
            //    sw.Write($"{dados}\n");

            //}
        }

    }
}


foreach (var file in danaDepArray)
{
    using (StreamReader sr = new StreamReader((string)file, Encoding.Default))
    {
        Console.WriteLine($"Lendo os arquivos:{Path.GetFileName((string?)file)} ");

        while ((dados = sr.ReadLine()) != null)
        {


            using (StreamWriter sw = new StreamWriter(@$"{relPastaGeral}\{formatada} DANADEP_concatenado\{formatada} DANADEP_concatenado.txt", true, Encoding.Default))
            {
                sw.Write($"{dados}\n");

            }
            //using (StreamWriter sw = File.AppendText(@$"{relPastaGeral}\{formatada} DANADEP_concatenado\{formatada} DANADEP_concatenado.txt"))
            //{
            //    sw.Write($"{dados}\n");

            //}
        }

    }
}




//============================================ COPIANDO ARQUIVOS ===================================
if (Directory.Exists(currentFolder))
{

    foreach (string s in titularesArray)
    {
        var fileName = Path.GetFileName(s);
        var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} ALL_TITULARES_concatenado\", fileName);
        File.Copy(s, destFile, true);
    }


}
else
{
    Console.WriteLine("Source path does not exist!");
}



if (Directory.Exists(currentFolder))
{
    foreach (string s in dependentesArray)
    {
        var fileName = Path.GetFileName(s);
        var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} ALL_DEPENDENTES_concatenado\", fileName);
        File.Copy(s, destFile, true);
    }


}
else
{
    Console.WriteLine("Source path does not exist!");
}
if (Directory.Exists(currentFolder))
{

    foreach (string s in bradescoArray)
    {


        var fileName = Path.GetFileName(s);
        var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} BRADESCO_concatenado\", fileName);
        File.Copy(s, destFile, true);
    }


}
else
{
    Console.WriteLine("Source path does not exist!");
}





{


    if (Directory.Exists(currentFolder))
    {

        foreach (string s in bradescoDepArray)
        {


            var fileName = Path.GetFileName(s);
            var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} BRADESCODEP_concatenado\", fileName);
            File.Copy(s, destFile, true);
        }
    }
    else
    {
        Console.WriteLine("Source path does not exist!");
    }






}


{
    Console.WriteLine("Aguarde...");





    if (Directory.Exists(currentFolder))
    {

        foreach (string s in danamedArray)
        {

            var fileName = Path.GetFileName(s);
            var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} DANAMED_concatenado\", fileName);
            File.Copy(s, destFile, true);
        }


    }
    else
    {
        Console.WriteLine("Source path does not exist!");
    }





}


{

    Console.WriteLine("Aguarde...");





    if (Directory.Exists(currentFolder))
    {

        foreach (string s in danaDepArray)
        {

            var fileName = Path.GetFileName(s);
            var destFile = Path.Combine(@$"{relPastaGeral}\{formatada} DANADEP_concatenado\", fileName);
            File.Copy(s, destFile, true);
        }


    }
    else
    {
        Console.WriteLine("Source path does not exist!");
    }

}

//========================================= DELETANDO ARQUIVOS =========================================

foreach (var arr in textArray)
{
    File.Delete(arr);
}

Console.WriteLine("Pressione qualquer tecla");
Console.ReadKey();