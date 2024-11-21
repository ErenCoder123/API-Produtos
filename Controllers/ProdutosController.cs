using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();

    [HttpGet]
    public ActionResult<List<Produto>> GetAll()
    {
        return produtos;
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> GetById(int id)
    {
        Produto produtoEncontrado = null;
        foreach (var produto in produtos)
        {
            if(produto.Id == id)
            {
                produtoEncontrado = produto;
                break;
            }
        }
        if(produtoEncontrado == null)
        {
            return NotFound();
        }
        return produtoEncontrado;
    }
    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        produtos.Add(produto);
        return Created();
    }
    [HttpPut("{id}")]
    public ActionResult Put(int id, Produto produtoAtualizado)
    {
        Produto produtoEncontrado = null;
        foreach (var produto in produtos)
        {
            if(produto.Id == id)
            {
                produtoEncontrado = produto;
                break;
            }
        }
        if(produtoEncontrado == null)
        {
            return NotFound();
        }
        produtoEncontrado.Nome = produtoAtualizado.Nome;
        produtoEncontrado.Preco = produtoAtualizado.Preco;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Produto produtoEncontrado = null;
        foreach (var produto in produtos)
        {
            if(produto.Id == id)
            {
                produtoEncontrado = produto;
                break;
            }
        }
        if(produtoEncontrado == null)
        {
            return NotFound();
        }
        produtos.Remove(produtoEncontrado);
        return NoContent();
    }

}