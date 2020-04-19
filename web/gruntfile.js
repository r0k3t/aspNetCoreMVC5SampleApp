/// <binding BeforeBuild='sass:dist' />


module.exports = function(grunt) {
    "use strict";
    var sass = require("node-sass");

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON("package.json"),

        // Sass
        sass: {
            options: {
                sourceMap: true, // Create source map
                implementation: sass,
                outputStyle: "nested" // Minify output
            },
            dist: {
                files: [
                    {
                        expand: true, // Recursive
                        cwd: "Styles", // The startup directory
                        src: ["**/*.scss"], // Source files
                        dest: "wwwroot/css", // Destination
                        ext: ".css" // File extension
                    }
                ]
            }
        }
    });

    // Load the plugin
    grunt.registerTask("default", ["sass"]);
    grunt.loadNpmTasks("grunt-sass");

    // Default task(s).


};