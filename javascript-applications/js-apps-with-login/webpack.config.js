// npm isntall webpack --save-dev
// npm install --save-dev babel-core babel-preset-es2015
// npm install --save-dev babel-loader
// http://webpack.github.io/docs/usage.html 
var webpack = require('webpack');

module.exports = {
    entry: './public/app/index.js',
    output: {
        path: './public',
        filename: 'app.bundle.js'
    },
    module: {
        loaders: [{
            test: /\.jsx?$/,
            exclude: /node_modules/,
            loader: 'babel-loader',
        }]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin({
            compress: {
                warnings: false,
            },
            output: {
                comments: false,
            }
        }),
    ]
};