/*global module:false*/
module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    // Metadata.
    pkg: grunt.file.readJSON('package.json'),
    // Task configuration.
    cssmin: {
        sitecss:{
            files: {
                'public/dist/assets/css/styles-1.0.0.min.css': [
                    'bower_components/bootswatch/paper/bootstrap.css',
                    'bower_components/animate.css/animate.css',
                    'bower_components/font-awesome/css/font-awesome.css',
                    'bower_components/toastr/toastr.css',
                    'bower_components/ng-img-crop/compile/minified/ng-img-crop.css'
                ]
            }
        }
    },
    uglify: {
      options: {
        compress: true
      },
      my_target: {
          files: {
              'public/dist/assets/js/scripts-1.0.0.min.js' : [
              'bower_components/jquery/dist/jquery.js',
              'bower_components/bootstrap/dist/js/bootstrap.js',
              'bower_components/toastr/toastr.js',
              'bower_components/angular/angular.js',
              'bower_components/angular-route/angular-route.js',
              'bower_components/ng-img-crop/compile/minified/ng-img-crop.js'
              ],
              'public/dist/assets/js/app-1.0.0.min.js' : [
              'app/app.js',
              'app/routes.js',
              'app/config.js'
              ],
              'public/dist/assets/js/factories-1.0.0.min.js' : [
              'app/factories/account-factory.js',
              'app/factories/category-factory.js',
              'app/factories/product-factory.js',
              ],
              'public/dist/assets/js/controllers-1.0.0.min.js' : [
              'app/controllers/home/home-controller.js',
              'app/controllers/account/login-controller.js',
              'app/controllers/account/logout-controller.js',
              'app/controllers/category/category-controller.js',
              'app/controllers/product/product-list-controller.js',
              'app/controllers/product/product-create-controller.js',
              'app/controllers/product/product-edit-controller.js'
              ]
          }
      }
    },
    copy: {
      main: {
          files: [{
              expand: true,
              cwd: 'bower_components/font-awesome/fonts/',
              src: '**',
              dest: 'public/dist/assets/font',
              flatten: false,
          }]
      }
    },
    htmlmin: {
        dist:{
            options: {
                removeComments: true,
                collapseWhitespace: true
            },
            files: {
                'public/dist/pages/shared/headbar.html': 'public/dev/pages/shared/headbar.html',
                'public/dist/pages/account/login.html': 'public/dev/pages/account/login.html',
                'public/dist/pages/category/index.html': 'public/dev/pages/category/index.html',
                'public/dist/pages/home/index.html': 'public/dev/pages/home/index.html',
                'public/dist/pages/product/index.html': 'public/dev/pages/product/index.html',
                'public/dist/pages/product/create.html': 'public/dev/pages/product/create.html',
                'public/dist/pages/product/edit.html': 'public/dev/pages/product/edit.html'
            }
        }      
    }
  });

  // These plugins provide necessary tasks.
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-copy');
  grunt.loadNpmTasks('grunt-contrib-htmlmin');

  // Default task.
  grunt.registerTask('dist', ['cssmin', 'uglify', 'copy', 'htmlmin']);

};
