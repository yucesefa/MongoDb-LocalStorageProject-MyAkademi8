using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Services.ProductServices;


namespace MongoDbProject.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IProductService _productService;

        public ExcelController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ExcelList()
        {
            return View();
        }
        public async Task<IActionResult> ProductWithCategoryExcelList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Ürünler");
                workSheet.Cell(1, 1).Value = "Ürün Adı";
                workSheet.Cell(1, 2).Value = "Kategori";
                var model = await _productService.GetProductWithCategoryExcelListAsync();

                int rowCount = 2;
                foreach (var item in model)
                {
                    workSheet.Cell(rowCount, 1).Value = item.Name;
                    workSheet.Cell(rowCount, 2).Value = item.Category.CategoryName;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content  = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductList.xlsx");
                }
            }
        }
    }
}
