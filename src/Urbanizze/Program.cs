using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins(
                "http://localhost:5500",
                "http://127.0.0.1:5500"
              )
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.PrefeiturasCidades.Any())
    {
        var sp = new PrefeituraCidade { Nome = "São Paulo", Uf = "SP" };
        var rj = new PrefeituraCidade { Nome = "Rio de Janeiro", Uf = "RJ" };
        var bh = new PrefeituraCidade { Nome = "Belo Horizonte", Uf = "MG" };
        db.PrefeiturasCidades.AddRange(sp, rj, bh);
        db.SaveChanges();

        var depIluminacao = new Departamento { Nome = "Iluminação", Descricao = "Iluminação pública", PrefeituraCidadeId = sp.Id };
        var depSaneamento = new Departamento { Nome = "Saneamento", Descricao = "Saneamento básico", PrefeituraCidadeId = sp.Id };
        var depPavimentacaoSP = new Departamento { Nome = "Pavimentação", Descricao = "Pavimentação de vias", PrefeituraCidadeId = sp.Id };
        var depLixoSP = new Departamento { Nome = "Lixo", Descricao = "Coleta de lixo", PrefeituraCidadeId = sp.Id };
        var depPavimentacaoRJ = new Departamento { Nome = "Pavimentação", Descricao = "Pavimentação de vias", PrefeituraCidadeId = rj.Id };
        var depLixoRJ = new Departamento { Nome = "Lixo", Descricao = "Coleta de lixo", PrefeituraCidadeId = rj.Id };
        var depMobilidade = new Departamento { Nome = "Mobilidade", Descricao = "Mobilidade urbana", PrefeituraCidadeId = bh.Id };
        db.Departamentos.AddRange(depIluminacao, depSaneamento, depPavimentacaoSP, depLixoSP, depPavimentacaoRJ, depLixoRJ, depMobilidade);
        db.SaveChanges();

        var cidadao1 = new Cidadao { Nome = "Carlos Mendes", Email = "carlos@email.com", Senha = "123456", Telefone = "11999990001", Cpf = "11111111111" };
        var cidadao2 = new Cidadao { Nome = "Maria Silva", Email = "maria@email.com", Senha = "123456", Telefone = "11999990002", Cpf = "22222222222" };
        var cidadao3 = new Cidadao { Nome = "João Souza", Email = "joao@email.com", Senha = "123456", Telefone = "21999990001", Cpf = "33333333333" };
        db.Cidadaos.AddRange(cidadao1, cidadao2, cidadao3);
        db.SaveChanges();

        var func1 = new Funcionario { CidadaoId = cidadao1.Id, DepartamentoId = depPavimentacaoSP.Id };
        db.Funcionarios.Add(func1);
        db.SaveChanges();

        var denuncias = new List<Denuncia>
        {
            new() { CidadaoId = cidadao1.Id, DepartamentoId = depIluminacao.Id, Titulo = "Poste sem luz na esquina", Descricao = "O poste da esquina da Rua das Acácias com a Av. Brasil está sem luz há mais de uma semana, gerando insegurança para os moradores.", Localizacao = "Rua das Acácias, 45 - Centro", StatusDenuncia = StatusDenuncia.ABERTA, CriadoEm = new DateTime(2026, 5, 12) },
            new() { CidadaoId = cidadao2.Id, DepartamentoId = depSaneamento.Id, Titulo = "Vazamento na via principal", Descricao = "Há um grande vazamento de água na via principal do bairro, causando alagamento e dificultando o tráfego de veículos e pedestres.", Localizacao = "Av. Principal, 200 - Jardim América", StatusDenuncia = StatusDenuncia.INDEFERIDA, CriadoEm = new DateTime(2026, 5, 12) },
            new() { CidadaoId = cidadao3.Id, DepartamentoId = depPavimentacaoRJ.Id, Titulo = "Buraco grande na pista", Descricao = "Há um buraco grande na Rua das Flores, número 123, que está causando acidentes e dificultando o trânsito. O buraco tem aproximadamente 2 metros de diâmetro e está em um local de grande circulação.", Localizacao = "Rua das Flores, 123 - Centro", StatusDenuncia = StatusDenuncia.EM_ANALISE, CriadoEm = new DateTime(2026, 5, 10) },
            new() { CidadaoId = cidadao1.Id, DepartamentoId = depLixoSP.Id, Titulo = "Lixo acumulado em terreno baldio", Descricao = "Terreno baldio na Rua dos Lírios acumula lixo há semanas, atraindo animais e causando mau cheiro.", Localizacao = "Rua dos Lírios, s/n - Vila Nova", StatusDenuncia = StatusDenuncia.ABERTA, CriadoEm = new DateTime(2026, 5, 9) },
            new() { CidadaoId = cidadao2.Id, DepartamentoId = depMobilidade.Id, Titulo = "Sinalização apagada no cruzamento", Descricao = "O semáforo do cruzamento da Av. Amazonas com Rua Goiás está apagado, causando confusão no trânsito.", Localizacao = "Av. Amazonas, 1500 - Savassi", StatusDenuncia = StatusDenuncia.EM_ANALISE, CriadoEm = new DateTime(2026, 5, 7) },
            new() { CidadaoId = cidadao3.Id, DepartamentoId = depPavimentacaoSP.Id, Titulo = "Recapeamento concluído", Descricao = "O recapeamento da Rua Augusta foi finalizado com sucesso.", Localizacao = "Rua Augusta, 800 - Consolação", StatusDenuncia = StatusDenuncia.CONCLUIDA, CriadoEm = new DateTime(2026, 5, 5) },
            new() { CidadaoId = cidadao1.Id, DepartamentoId = depLixoRJ.Id, Titulo = "Falta de coleta seletiva", Descricao = "O bairro não recebe coleta seletiva há mais de duas semanas.", Localizacao = "Rua Barata Ribeiro, 300 - Copacabana", StatusDenuncia = StatusDenuncia.CONCLUIDA, CriadoEm = new DateTime(2026, 5, 3) },
            new() { CidadaoId = cidadao2.Id, DepartamentoId = depPavimentacaoSP.Id, Titulo = "Calçada quebrada na escola", Descricao = "A calçada em frente à Escola Municipal Santos Dumont está toda quebrada, oferecendo risco aos pedestres.", Localizacao = "Rua Santos Dumont, 50 - Liberdade", StatusDenuncia = StatusDenuncia.ABERTA, CriadoEm = new DateTime(2026, 5, 1) }
        };
        db.Denuncias.AddRange(denuncias);
        db.SaveChanges();

        var mensagens = new List<Mensagem>
        {
            new() { DenunciaId = denuncias[2].Id, CidadaoId = cidadao3.Id, Texto = "Boa tarde, gostaria de saber quando vão resolver esse problema. O buraco está crescendo.", CriadoEm = new DateTime(2026, 5, 10, 10, 30, 0) },
            new() { DenunciaId = denuncias[2].Id, FuncionarioId = func1.Id, Texto = "Olá, já encaminhamos sua denúncia para a equipe responsável. Em breve entraremos em contato com previsão de reparo.", CriadoEm = new DateTime(2026, 5, 10, 14, 15, 0) },
            new() { DenunciaId = denuncias[2].Id, CidadaoId = cidadao3.Id, Texto = "Obrigado pela atenção!", CriadoEm = new DateTime(2026, 5, 10, 14, 20, 0) }
        };
        db.Mensagens.AddRange(mensagens);
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("FrontendPolicy");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
