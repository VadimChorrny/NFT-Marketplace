var path = require("path");

module.exports = {
    entry: [
        "babel-polyfill",
        "./src/main"
    ],
    output: {
        publicPath: "/js/",
        path: path.join(__dirname, "/wwwroot/js/"),
        filename: "main.build.js"
    }
};