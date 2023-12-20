using EInsuranceProject.DTO;
using EInsuranceProject.Model;
using EInsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EInsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet("GetAllDocuments")]
        public async Task<IActionResult> GetDocuments()
        {
            string[] innerTable = { };
            var documents = await _documentService.GetAll(innerTable);
            var documentDTOS = new List<DocumentDTO>();
            foreach (var document in documents)
            {
                documentDTOS.Add(ConvertToDocumentDTO(document));
            }
            return Ok(documentDTOS);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByID([FromQuery] int Id)
        {

            var document = await _documentService.GetById(Id);
            var documentDTO = ConvertToDocumentDTO(document);
            return Ok(documentDTO);
        }
        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocument([FromBody] DocumentDTO documentDTO)
        {
            var newDocument = ConvertToDocument(documentDTO);
            await _documentService.AddDocument(newDocument);
            return Ok(newDocument);
        }
        [HttpPut("UpdateDocument")]
        public async Task<IActionResult> Update([FromBody] DocumentDTO documentDTO)
        {
            var newDocument= ConvertToDocument(documentDTO);
            await _documentService.UpdateDocument(newDocument);
            return Ok("Updated Successfully");
        }
        [HttpDelete("DeleteDocument/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentService.DeleteDocument(id);

            return Ok("Removed Successfully");


        }
        private Document ConvertToDocument(DocumentDTO documentDTO)
        {
            var Document = new Document()
            {
                
                DocumentId = documentDTO.DocumentId,
                DocumentName= documentDTO.DocumentName,
                DocumentType = documentDTO.DocumentType,
                CustomerId= documentDTO.CustomerId,
                status= documentDTO.Status,
            };
            return Document;

        }
        private DocumentDTO ConvertToDocumentDTO(Document document)
        {
            var DocumentDTO = new DocumentDTO()
            {
                DocumentId = document.DocumentId,
                DocumentName = document.DocumentName,
                DocumentType = document.DocumentType,
                CustomerId = document.CustomerId,
                Status=document.status,

            };
            return DocumentDTO;
        }
    }
}
