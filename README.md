# 🧾 EasyReceipt API - Gerador de Recibos Profissional

Esta é uma Web API desenvolvida em **.NET 10** focada na geração automatizada de recibos em PDF. O projeto foi estruturado para ser simples, eficiente e demonstrar práticas modernas de desenvolvimento backend.

## 🚀 Tecnologias e Ferramentas

* **Linguagem:** C#
* **Framework:** ASP.NET Core (Web API)
* **Versão do SDK:** .NET 10 (Preview/Latest)
* **Geração de PDF:** QuestPDF
* **Documentação:** Swagger (OpenAPI)

## 🛠️ Desafios Superados

Como o projeto foi desenvolvido na versão mais recente do .NET (v10), enfrentei desafios interessantes de arquitetura:
* **Resolução de Conflitos:** Ajuste manual de namespaces e referências de assembly (OpenApi vs local).
* **Layout Dinâmico:** Implementação de um design de recibo profissional com bordas, alinhamentos e campos de assinatura utilizando a biblioteca QuestPDF.
* **Ambiente de Desenvolvimento:** Configuração e troubleshooting de processos bloqueados no ambiente Windows.

## 📋 Como Testar

1.  Certifique-se de ter o SDK do .NET instalado.
2.  Clone o repositório e navegue até a pasta:
    ```bash
    cd EasyReceiptAPI
    ```
3.  Execute o projeto:
    ```bash
    dotnet run
    ```
4.  Acesse a interface do Swagger em: `http://localhost:5169/swagger` (verifique a porta no seu terminal).

---
**Desenvolvido por Maline Lilac** Estudante de Engenharia de Software e Estagiária de Desenvolvimento no FGV IBRE.
