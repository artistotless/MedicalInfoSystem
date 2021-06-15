using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace MedicalTrader
{
    class OfferDocument
    {

        private static Random rand = new Random();

        private static string TableSampleResourcesDirectory = Environment.CurrentDirectory + @"\";
        private static string TableSampleOutputDirectory = Environment.CurrentDirectory + @"\";


        public static void PrintToWord(DrugOffer offer, string indexFile)
        {

            // Create a document.
            using (var document = DocX.Create(TableSampleOutputDirectory + @"offer_" + indexFile + ".docx"))
            {
                // Add a title




                document.InsertParagraph("Общество с ограниченной ответственностью").FontSize(14d).Font("Times New Roman").Bold(true).SpacingAfter(35d).Alignment = Alignment.center;

                document.InsertParagraph("«ООО ТРЭЙД ФАРМ").FontSize(18d).Font("Times New Roman").Bold(true).SpacingAfter(20d).Alignment = Alignment.center;
                document.InsertParagraph("360021, Кабардино-Балкарская Республика, г. Нальчик").FontSize(14d).Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.left;
                document.InsertParagraph("ИНН 0259012740, КПП 025901001, ОГРН 1130280045862".ToUpper()).FontSize(14d).Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.left;
                document.InsertParagraph("БИК 043602955 к/с 3010081738266601").FontSize(14d).Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.left;
                document.InsertParagraph("Тел. 8-964-039-80-86").FontSize(14d).Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.left;
                document.InsertParagraph("Email: aslanboziev7124811@gmail.com").FontSize(14d).Font("Times New Roman").SpacingAfter(20d).Alignment = Alignment.left;
                document.InsertParagraph("Коммерческое предложение для " + offer.companyName).FontSize(16d).Bold(true).Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.center;
                document.InsertParagraph("Уважаемые господа,").FontSize(14d).Font("Times New Roman").SpacingAfter(15d).Alignment = Alignment.left;
                document.InsertParagraph("Настоящим предагаем вам рассмотреть вопрос о сотрудничестве с нашей компанией.").FontSize(14d).Font("Times New Roman").SpacingAfter(15d).Alignment = Alignment.left;
                document.InsertParagraph("На основании вашего запроса, мы можем предложить вам следующий вариант:").FontSize(14d).Font("Times New Roman").SpacingAfter(40d).Alignment = Alignment.center;






                var t = document.AddTable(offer.drugArray.Count + 1, 6);
                t.Design = TableDesign.TableGrid;
                t.Alignment = Alignment.center;
                var sum = 0;
                var p = document.InsertParagraph("Лекарственные препараты:").Bold(true).SpacingAfter(10d);


                t.Rows[0].Cells[0].Paragraphs[0].Append("N");
                t.Rows[0].Cells[1].Paragraphs[0].Append("Наименование");
                t.Rows[0].Cells[2].Paragraphs[0].Append("Кол-во");
                t.Rows[0].Cells[3].Paragraphs[0].Append("Изготовитель");
                t.Rows[0].Cells[4].Paragraphs[0].Append("Страна");
                t.Rows[0].Cells[5].Paragraphs[0].Append("Удостоверение");

                int row = 1;


                foreach (var drug in offer.drugArray)

                {

                    t.Rows[row].Cells[0].Paragraphs[0].Append(row.ToString());
                    t.Rows[row].Cells[1].Paragraphs[0].Append(drug.nomenclature);
                    t.Rows[row].Cells[2].Paragraphs[0].Append(drug.quantity.ToString());
                    t.Rows[row].Cells[3].Paragraphs[0].Append(drug.manufacturer.ToString());
                    t.Rows[row].Cells[4].Paragraphs[0].Append(drug.country.ToString());
                    t.Rows[row].Cells[5].Paragraphs[0].Append(drug.certNumber.ToString());
                    sum += drug.price;


                    row++;
                }


                p.InsertTableAfterSelf(t).Alignment = Alignment.center;

                document.InsertParagraph("Итого: " + sum.ToString()+" Руб.").FontSize(14d).Font("Times New Roman").SpacingBefore(20d).Alignment = Alignment.left;


                document.Save();
                Process.Start(TableSampleOutputDirectory + @"offer_" + indexFile + ".docx");
                Console.WriteLine("\tCreated\n");
            }
        }
    }
}

