// Regenerate a SPARQL query from a JSON object
var generator = new sparqljs.Generator();
query.variables = ['?mickey'];
var generatedQuery = generator.stringify(query);

$.getJSON('http://data.europa.eu/euodp/sparqlep', generatedQuery, function(){
    console.log('yes');
});

