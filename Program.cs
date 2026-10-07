using System.Text.Json;

Console.WriteLine("=== CONSULTA VIA CEP ===");
Console.WriteLine();

Console.Write("Digite o CEP: ");
string? cep = Console.ReadLine();

string url = $"https://viacep.com.br/ws/{cep}/json/";

using HttpClient cliente = new HttpClient();

string resposta = await cliente.GetStringAsync(url);

Endereco? endereco = JsonSerializer.Deserialize<Endereco>(
    resposta,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    }
);

Console.WriteLine();
Console.WriteLine("=== ENDEREÇO ENCONTRADO ===");
Console.WriteLine($"CEP: {endereco?.Cep}");
Console.WriteLine($"Logradouro: {endereco?.Logradouro}");
Console.WriteLine($"Bairro: {endereco?.Bairro}");
Console.WriteLine($"Cidade: {endereco?.Localidade}");
Console.WriteLine($"UF: {endereco?.Uf}");
Console.WriteLine($"Complemento: {endereco?.Complemento}");