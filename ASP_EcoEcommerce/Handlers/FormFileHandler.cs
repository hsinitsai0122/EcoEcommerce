namespace ASP_EcoEcommerce.Handlers
{
    public static class FormFileHandler
    {
        public static async Task<string> SaveFile(this IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
