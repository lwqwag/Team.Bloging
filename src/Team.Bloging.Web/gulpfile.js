"use strict";

var gulp = require("gulp"),
    path = require('path'),
    copyResources = require('./node_modules/@abp/aspnetcore.mvc.ui/gulp/copy-resources.js'),
    paths = {
        src: "node_modules",
        dest: "wwwroot/libs/"
    };
    const copyFolders = [
        "highlight.js",
        "owl.carousel"];
    const copyFiles = [
        "highlight.js/lib/highlight.js",
        "owl.carousel/dist/owl.carousel.js",
         "owl.carousel/dist/owl.carousel.min.js"];
    
exports.default = function(){
    return copyResources(path.resolve('./'));
};
//复制文件
gulp.task('copy:file', () => {
    //循环遍历文件列表
   
    var tasks = copyFiles.map(function (file) {
        console.log(file);
    //拼接文件完整路径
    var scrFullPath = path.join(paths.src, file);
    //拼接完整目标路径
    var index = file.lastIndexOf('/');
    var destPath = file.substring(index+1, index+1);
    console.log(destPath);
    
    var destFullPath=path.join(paths.dest, destPath);
    return gulp.src(scrFullPath)
    .pipe(gulp.dest(destFullPath));
    
    });
    
    });
    
    //复制文件夹
    gulp.task('copy:folder', () => {
    var tasks = copyFolders.map(function (folder) {
    //拼接完整目标路径
    var destFullPath = path.join(paths.dest, folder);
    return gulp.src(path.join(paths.src, folder + '/**/*'))
    .pipe(gulp.dest(destFullPath));
    });
});
