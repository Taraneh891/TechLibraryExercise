(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["Book"],{c71c:function(t,o,a){"use strict";a.r(o);var n=function(){var t=this,o=t.$createElement,a=t._self._c||o;return t.book?a("div",[a("b-card",{staticClass:"mb-2",staticStyle:{"max-width":"30rem"},attrs:{title:t.book.title,"img-src":t.book.thumbnailUrl,"img-alt":"Image","img-top":"",tag:"article"}},[a("b-card-text",[t._v(" "+t._s(t.book.descr)+" ")]),a("b-button",{attrs:{to:"/",variant:"primary"}},[t._v("Back")])],1)],1):t._e()},e=[],i=a("bc3a"),c=a.n(i),r={name:"Book",props:["id"],data:function(){return{book:null}},mounted:function(){var t=this;c.a.get("https://localhost:5001/books/".concat(this.id)).then((function(o){t.book=o.data}))}},s=r,l=a("2877"),b=Object(l["a"])(s,n,e,!1,null,null,null);o["default"]=b.exports}}]);
//# sourceMappingURL=Book.992f26b6.js.map