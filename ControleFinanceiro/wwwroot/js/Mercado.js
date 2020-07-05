$(document).ready(function () {

	var url = window.location.pathname;

	if (url.indexOf("Edit") > 0) {

		var id = $("#MercadoId").val();
		ListarProdutos(id);
	}
});

function SalvarLista() {

	//Data
	var mercadoData = $("#MercadoData").val();

	//Nome
	var mercadoNome = $("#MercadoNome").val();

	//Valor
	var mercadoValor = $("#MercadoValor").val();

	//StatusCompra
	var statusId = $("#StatusId").val();

	//Categoria
	var categoriaId = $("#CategoriaId").val();

	//FormaPagamento
	var formaId = $("#FormaId").val();

	var token = $('input[name="__RequestVerificationToken"]').val();

	var tokenadr = $('form[action="/ListaMercados/Create"] input[name="__RequestVerificationToken"]').val();
	var headers = {};
	var headersadr = {};
	headers['__RequestVerificationToken'] = token;
	headersadr['__RequestVerificationToken'] = tokenadr;

	//Gravar
	var url = "/ListaMercados/Create";

	$.ajax({
		url: url
		, type: "POST"
		, dataType: "json"
		, headers: headersadr
		, data: { MercadoId: 0, MercadoData: mercadoData, MercadoNome: mercadoNome, MercadoValor: mercadoValor, StatusId: statusId, CategoriaId: categoriaId, FormaId: formaId, __RequestVerificationToken: token }
		, success: function (data) {
			if (data.Resultado > 0) {
				ListarProdutos(data.Resultado);
			}
		}
	});
}


function ListarProdutos(idMercado) {

	var url = "/ProdutosMercado/ListarProdutos";

	$.ajax({
		url: url
		, type: "GET"
		, data: { id: idMercado }
		, datatype: "html"
		, success: function (data) {
			var divProdutos = $("#divProdutos");
			divProdutos.empty();
			divProdutos.show();
			divProdutos.html(data);
		}
	});
}

function SalvarProdutos() {

	var quantidade = $("#Quantidade").val();
	var produto = $("#ProdutoNome").val();
	var valorunitario = $("#ValorUnitario").val();
	var idMercado = $("#idMercado").val();

	var url = "/ProdutosMercado/SalvarProdutos";

	$.ajax({
		url: url
		, data: { ProdutoId: 0, quantidade: quantidade, produto: produto, valorunitario: valorunitario, idMercado: idMercado }
		, type: "GET"
		, datatype: "html"
		, success: function (data) {
			if (data.Resultado > 0) {
				ListarProdutos(idMercado);
			}
		}
	});
}

function ExcluirItem(id) {

	var url = "/ProdutosMercado/Excluir";

	$.ajax({
		url: url
		, data: { id : id }
		, dataType: "json"
		, type: "POST"
		, success: function (data) {
			if (data.Resultado) {
				var linha = "#tr" + id;
				$(linha).fadeOut(id);
				//$(linha).fadeOut(500);
				
			}
		}
	});
}
