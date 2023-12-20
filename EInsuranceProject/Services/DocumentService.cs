using EInsuranceProject.Exceptions;
using EInsuranceProject.Model;
using EInsuranceProject.Repository;
using System.Linq.Expressions;

namespace EInsuranceProject.Services
{
    public class DocumentService : IDocumentService
    {
        private IEntityRepository<Document> _repository;

        public DocumentService(IEntityRepository<Document> entityRepository)
        {
            _repository = entityRepository;
        }
        public async Task AddDocument(Document document)
        {
            await _repository.Insert(document);
        }

        public async Task<bool> DeleteDocument(int id)
        {
            var DocToDelete = await _repository.GetById(id);
            if (DocToDelete != null)
                return await _repository.Delete(id);
            throw new DataNotFoundExcpetion("No Documnet Data found");
        }

        public async Task<IEnumerable<Document>> GetAll(string[] innerTables)
        {
            Expression<Func<Document, bool>> filterPredicate = e => e.status == true;
            var documents = await _repository.GetAll(innerTables, filterPredicate);
            if (documents.Any())
            {
                return documents;
            }
            throw new DataNotFoundExcpetion("No Document  found");
        }

        public async Task<Document> GetById(int Id)
        {
            var document = await _repository.GetById(Id);
            if (document != null)
            {
                return document;
            }
            throw new DataNotFoundExcpetion("No document Data found");
        }

        public async Task<bool> UpdateDocument(Document document)
        {
            var DocToUpdate = await _repository.GetById(document.DocumentId);
            if (DocToUpdate != null)
            {
                return await _repository.Update(document,  document.DocumentId);
            }
            throw new DataNotFoundExcpetion("No Document Data found");
        }
    }
}
