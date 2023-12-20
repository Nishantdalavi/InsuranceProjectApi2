using EInsuranceProject.Model;

namespace EInsuranceProject.Services
{
    public interface IDocumentService
    {
        public Task<IEnumerable<Document>> GetAll(string[] innerTables);
        public Task<Document> GetById(int Id);
        public Task AddDocument(Document document);
        public Task<bool> UpdateDocument(Document document);
        public Task<bool> DeleteDocument(int id);

    }
}
