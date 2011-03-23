









if( superfish ){
}else{
    if( window == top ){
       if( window.location.href.indexOf( "amazon.com/" ) > 0 && window.location.href.indexOf( "/search/" ) > 0 && window.location.href.indexOf( "#sf" ) > 0 ){
            window.location.replace( window.location.href.substring( 0, window.location.href.indexOf( "#sf" ) ) );
       }
        spsupport = {};
        spsupport.log = function( m ){
            if( window.console ){
                console.log( m );
            }
        };
        
        spsupport.sites = {
    rules: function(){
        var site = spsupport.api.getDomain();
        site = site.substr(0, site.indexOf(".")).replace(/-/g, "_");
        return eval( "spsupport.sites._" + site);
    },

    isBlackStage: function() {
        var r = this.rules();
        if( r && r.isBlackStage ){
            return r.isBlackStage();
        }
        return false;
    },

    care : function(){
        var r = this.rules();
        if( r && r.care ){
            r.care();
        }
    },
    validRefState : function(){ // Valid Refresh State
        var r = this.rules();
        if( r && r.validRefState ){
            return r.validRefState();
        }
        return 1;
    },

    vImgURL : function( iU ){ // Validate IMG URL
        var r = this.rules();
        if( r && r.vImgURL ){
            return r.vImgURL( iU );
        }
        return ( iU );
    },

    preInject : function(){
        var r = this.rules();
        if( r && r.preInject ){
            r.preInject();
        }
    },

    validProdImg : function(){
        var r = this.rules();
        if( r && r.validProdImg ){
            return r.validProdImg();
        }
        return 0;
    },

    imgSupported : function( img ){
        var r = this.rules();
        if( r && r.imgSupported ){
            return r.imgSupported( img );
        }
        return 1;
    },

    ph2bi : function(){ // Plugin have to be injected
        var r = this.rules();
        if( r && r.ph2bi ){
            return r.ph2bi();
        }
        return 0;
    },

    gRD : function(){ // Get Refresh Delay
        var r = this.rules();
        if( r && r.gRD ){
            return r.gRD();
        }
        return 500;
    },

    gFU : function(){ // Get favicon URL
        var r = this.rules();
        if( r && r.gFU ){
            return r.gFU();
        }
        return( "http://www." +  spsupport.api.getDomain() + "/favicon.ico?p=" + new Date().getTime() );
    },


    gVI : function(){ // get Images Node
        var r = this.rules();
        if( r && r.gINode ){
            return r.gVI();
        }
        return 0;
    },

    inURL : function( u ){
        return ( window.location.href.indexOf( u ) > -1);
    },

    _google : {
        isBlackStage: function() {
            if(window.sufio && window.sufio.isIE == 7 || (+document.documentMode) == 7) {
                return true;
            }
            return false;
        },

        care : function(){
            var ssg = superfish.sg;
            if (ssg) {
                ssg.sSite = superfish.b.searchget;
                ssg.nodeType = 'li';
            }
            if( window.sufio.isIE != 7 ){
                try{
                    sufio.require("dojo.hash");
                    sufio.addOnLoad(function(){
                        sufio.subscribe("/dojo/hashchange", null,  function(){
                            spsupport.api.killIcons();
                            spsupport.sites._google.killSU();
                            spsupport.sites._google.killSg();
                            spsupport.sites._google.vIcons();
                        } );
                    });
                }catch(e){
                }

                var db = sufio.body();
                if( db && !db.evAdded ){
                    sufio.connect(
                        db,
                        "onkeydown", function(e){
                            spsupport.api.killIcons();
                            spsupport.sites._google.killSU();
                            var ch;
                            if(e && e.which){
                                ch = e.which;
                            }else if( window.event ){
                                ch = window.event.keyCode;
                            }
                            if(ch == 45) {
                                spsupport.sites._google.vIcons();
                            }
                            if(ch == 13) {
                                spsupport.sites._google.killSg();
                                spsupport.sites._google.vIcons();
                            }
                        });
                    db.evAdded = 1;
                }
            }
        },

        gVI : function (){
            var iu = spsupport.sites.inURL;
            return ( (iu("books.google" ) || iu("tbm=bks") || iu("tbs=bks") ) ? 0 : sufio.query('img[class *= "productthumb"]') );
        },

        vIcons : function(){
            setTimeout(
                function(){
                    var ss = spsupport.sites;
                    var sa = spsupport.api;
                    var iu = ss.inURL;
                    var im = ss._google.gVI();
                    if( sufio.query('li[id = "productbox"]').length > 0 ){
                        if( im.length > 0 ){
                            sa.startDOMEnumeration();
                            setTimeout( function(){
                                sa.wRefresh( 300 );
                            }, 800 );
                        }
                    }
                    else if( iu( "tbs=shop" )){
                        sa.startDOMEnumeration();
                        setTimeout( function(){
                            sa.wRefresh( 350 );
                        }, 800 );
                    }
                    else if(  iu("books.google" ) || iu("tbs=bks") ){ //|| iu("tbm=bks")
                        sa.startDOMEnumeration();
                        setTimeout( function(){
                            sa.wRefresh( 350 );
                        }, 800 );
                    }
                }, 1400 );
        },

        ph2bi : function(){
            return 1;
        },

        validRefState : function(){
            var iu = spsupport.sites.inURL;
            return  ( ( sufio.query('li[id = "productbox"]').length > 0 &&
                sufio.query('img[class *= "productthumb"]').length > 0 )
            || iu("tbs=shop")
                || iu("products/catalog" )
                || iu("books.google" )
                || iu("tbm=bks")
                || iu("tbs=bks")
                );
        },

        preInject : function(){
            var b = window.sufio.isIE;
            var iu = spsupport.sites.inURL;
            if( b != 7 && b != 6 ){
                var sIU = spsupport.p.supportedImageURLs;
                if ( sIU ){
                    sIU[ sIU.length ] = "jpg;base64";
                    sIU[ sIU.length ] = "jpeg;base64";
                }else{
                    sIU = [ "jpg;base64", "jpeg;base64" ];
                }

                if( iu("books.google" ) ){
                    var wN = sufio.query('div[id *= "_sliders"]')
                    if( wN.length > 0  ){
                        sufio.forEach( wN,function( n ) {
                            spsupport.domHelper.addEListener( n, spsupport.api.onDOMSubtreeModified, "DOMSubtreeModified");
                        });
                    }
                }
            }
        },

        validProdImg : function(){
            if( sufio.query('li[id = "productbox"]').length > 0  && !this.prodImg ){
                this.prodImg = 1;
                return 1;
            }
            return 0;
        },

        imgSupported : function( im ){
            if( im.id && im.id.indexOf("vidthumb")> -1 ||
                im.className.indexOf("vidthumb") > -1 ||
                im.className.indexOf("imgthumb") > -1 ){
                return 0;
            }
            return 1;
        },

        killSU : function(){
            this.prodImg = 0;
            try{
                var sfPP = spsupport.p.prodPage;
                sfPP.s = 0;
                sfPP.i = 0;
                sfPP.p = 0;
                sfPP.e = 0;
                var bC = sufio.byId("SF_SLIDE_UP_CLOSE");
                if( bC ){
                    sufio.attr( bC, "upp", 0 );
                    superfish.b.closePSU( bC, 4 );
                }
            }catch(ex){}
        },
   
        killSg : function(){
            if (superfish.sg) {
                superfish.sg.close();
            }
        },

        gFU : function(){ // Get favicon URL
            var src = "http://www." +  spsupport.api.getDomain() + superfish.util.slasher + "favicon.ico";
            superfish.util.slasher += '/';
            return src;
        }
    },


    _thefind : {
        care : function(){
            if( window.sufio.isIE != 7 ){
                try{
                    sufio.require("dojo.hash");
                    sufio.addOnLoad(function(){
                        sufio.subscribe("/dojo/hashchange", null,  function(){
                            spsupport.api.killIcons();
                            setTimeout( function(){
                                spsupport.api.startDOMEnumeration();
                            }, 3200 );
                            setTimeout( function(){
                                spsupport.api.wRefresh( 500 );
                            }, 4000 );
                        } );
                    });
                }catch(e){
                }
            }
        }
    },


    _macys : {
        care : function(){
            setTimeout( function(){
                spsupport.sites._macys.paging();
            }, 1000 );

            this.urlChange();
        },

        urlChange : function(){

            if( window.sufio.isIE != 7 && spsupport.sites.inURL( "productsPerPage" ) ){
                try{
                    sufio.require("dojo.hash");
                    sufio.addOnLoad(function(){
                        setTimeout( function(){
                            spsupport.api.wRefresh( 300 );
                        }, 2000 );
                        setTimeout( function(){
                            spsupport.sites._macys.paging();
                        }, 1500 );
                        sufio.subscribe("/dojo/hashchange", null,  function(){
                            if( !spsupport.sites._macys.evtc ){
                                spsupport.api.killIcons();
                                setTimeout( function(){
                                    spsupport.api.startDOMEnumeration();
                                }, 1700 );
                                setTimeout( function(){
                                    spsupport.api.wRefresh( 300 );
                                }, 2700 );
                                setTimeout( function(){
                                    spsupport.sites._macys.paging();
                                }, 3500 );
                            }
                        } );
                    });
                }catch(e){
                }
            }
        },

        paging : function(){
            var pgn = sufio.query('.paginationSpacer');
            if( pgn.length > 0 ){
                setTimeout(
                    function(){
                        sufio.forEach(
                            pgn,
                            function( lnk ) {
                                var tDel = 1500;
                                sufio.connect( lnk, "onmouseup", function(){
                                    spsupport.api.killIcons();
                                    spsupport.sites._macys.evtc = 1;
                                    setTimeout( function(){
                                        spsupport.api.startDOMEnumeration();
                                    }, tDel );
                                    setTimeout( function(){
                                        spsupport.api.wRefresh( tDel / 3 );
                                    },  tDel * 2 );
                                    setTimeout( function(){
                                        spsupport.sites._macys.paging();
                                    }, tDel * 2.5 );
                                } );
                            });
                    }, 1400);
                this.evtc = 0;
            }
        }
    },


    _yahoo : {
        vImgURL : function( u ){
            var uD = u.split( "http" );
            if( uD.length > 2 ){
                uD = uD[ 2 ];
            }else if( uD.length == 2){
                uD = uD[ 1 ];
            }else{
                uD = uD[ 0 ];
            }
            uD = uD.split( "&" );
            uD = uD[ 0 ];
            return "http" + uD;
        },

        validProdImg : function(){
            return 1;
        }
    },

    //    _boscovs :{
    //        vImgURL : function( u ){
    //            return u.split(";")[0];
    //        }
    //    },

    _amazon : {
        care : function(){
            this.foxlingo();
            this.paging();
            this.widget();
            this.urlChange();
        },

        gRD : function(){
            return 1300;
        },

        foxlingo : function(){
            if( !sufio.isIE &&
                spsupport.p.dlsource == "foxlingo" ){
                superfish.b.inj( superfish.b.site + "json/currencyRate.json?d=" + spsupport.api.getDateFormated(), 1, 1,
                    function(){
                        superfish.b.currency.addCurrency('$', superfish.b.curRequested )
                    } );
            }
        },
        paging : function(){
            var pgn = sufio.query('.pagnLink, .pagnPrev, .pagnNext, a[href *= "#/ref"]');
            if( pgn.length > 0 ){
                setTimeout(
                    function(){
                        sufio.forEach(
                            pgn,
                            function( lnk ) {
                                var tDel = 900;
                                sufio.connect( lnk, "onmouseup",
                                    function(){
                                        if ( !spsupport.sites._amazon.evCatch ){
                                            spsupport.sites._amazon.evCatch = 1;
                                            spsupport.api.wRefresh( tDel/1.3 );
                                            setTimeout( "spsupport.sites._amazon.paging(); spsupport.sites._amazon.evCatch = 0;", tDel * 3 );
                                        }
                                    } );
                            });
                    }, 1400);
            }
        },

        urlChange : function (){
            if( window.sufio.isIE != 7 ){
                try{
                    sufio.require("dojo.hash");
                    sufio.addOnLoad(function(){
                        sufio.subscribe("/dojo/hashchange", null,
                            function(){
                                if ( !spsupport.sites._amazon.evCatch ){
                                    spsupport.sites._amazon.evCatch = 1;
                                    spsupport.api.killIcons();
                                    setTimeout( function(){
                                        spsupport.api.startDOMEnumeration();
                                    }, 1900 );
                                    setTimeout( function(){
                                        spsupport.sites._amazon.paging();
                                        spsupport.api.wRefresh( 400 );
                                        spsupport.sites._amazon.evCatch = 0;
                                    }, 3000 );
                                }
                            } );
                    });
                }catch(e){
                }
            }
        },
        widget : function(){
            if( sufio.query('div[class = "shoveler"]').length > 0 ){
                setTimeout(
                    function(){
                        sufio.query('.back-button, .next-button').forEach(
                            function( btn ) {
                                sufio.connect( btn, "onmouseup", function(){
                                    spsupport.api.wRefresh(450);
                                } );
                            });
                    }, 1400);
            }
        }
    },
    _sears : {
        care : function(){
            this.widget();
        },
        widget : function(){
            if( sufio.query('div[id *= "rr_placement_"]').length > 0 ){
                sufio.query('div[class = "previous-disabled"]').forEach(
                    function( btn ) {
                        sufio.connect( btn, "onmouseup", function(){
                            spsupport.api.wRefresh(1000);
                        } );
                    });
                sufio.query('div[class *= "next"]').forEach(
                    function( btn ) {
                        sufio.connect( btn, "onmouseup", function(){
                            spsupport.api.wRefresh(1000);
                        } );
                    });
            }
        }
    }
};
        var superfish = {};
superfish.b = {};


        
        superfish.b.site            = "https://www.superfish.com/ws/";

        superfish.b.ip              = "189.115.138.37, 206.41.8.20";
        superfish.b.userid          = "OUNENzc3RjktN0JERi00NE";
        superfish.b.appVersion      = "6.2.9";
        superfish.b.clientVersion   = "1.2.0.7";
        superfish.b.wlVersion       = "2.0";
        superfish.b.cdnUrl          = "http://ajax.googleapis.com/ajax/libs/dojo/1.5.0/";
        superfish.b.pluginDomain    = "https://www.superfish.com/ws/";
        superfish.b.dlsource        = "ietab";
        superfish.b.statsReporter   = true;
        superfish.b.CD_CTID         = "";
        superfish.b.w3iAFS          = "";
        
superfish.b.images = 'ietab';
superfish.b.dragTopWidth = '232';
superfish.b.dragTopLeft = '247';
superfish.b.borderColor = '#749028';
superfish.b.arrFill = '#F8FBC7';
superfish.b.arrBorder = '#265e31';
superfish.b.shareMsgProd = 'Window Shopper';
superfish.b.shareMsgUrl = 'www.superfish.com';
superfish.b.suEnabled = 0;
superfish.b.partnerCustomUI = 1;
superfish.b.psuTitleColor = '#FFFFFF';
superfish.b.psuSupportedBy = 1;
superfish.b.psuSupportedByText = 'by Superfish';
superfish.b.psuSupportedByLink = 'http://www.superfish.com';
superfish.b.psuSupportedByTitle = 'Click for More Information';
superfish.b.isPublisher = false;
superfish.b.ignoreWL = 0;
superfish.b.icons = 1;
superfish.b.coupons = 0;
superfish.b.searchget = 8;
superfish.b.logoAnimated = 1;
superfish.b.partnerSgPausePopup = 'The Superfish visual <br>search engine will be <br>disabled for 24 hours';
superfish.b.partnerPausePopup = 'The Window Shopper <br>slide-up feature will be <br>disabled for 24 hours';




        superfish.b.inj = function(url, js, ext, cBack) {
    var d = document;
    var head = d.getElementsByTagName('head')[0];
    var src = d.createElement( js ? "script" : 'link' );
    url = ( ext ? "" :  superfish.b.site ) + url;

    if( js ){      
        src.type = "text/javascript";
        src.src = url;
    }else{
        src.rel = "stylesheet";
        src.href = url;
    }

    if(cBack) {
        // most browsers
        src.onload = ( function( prm ){
            return function(){
                cBack( prm );
            }
        })( url );
        // IE 6 & 7        
        src.onreadystatechange = ( function( prm ) {
            return function(){
                if (this.readyState == 'complete' || this.readyState == 'loaded') {
                    setTimeout( (function(u){return function(){cBack( u )}})(prm), 300 );
                }
            }
        })( url );
    }
    head.appendChild(src);
    return src;
};

        superfish.partner = {};

superfish.partner.init = function() {
    if (this._init) {
        this._init();
    }
};

        superfish.publisher = {};
superfish.publisher.reqCount = 0;
superfish.publisher.imgs = [];
// superfish.publisher.multiSu = 0;

superfish.publisher.init = function() {
    if (this._init) {
        this._init();
    }
};

superfish.publisher.pushImg = function(img) {
    if(superfish.b.isPublisher && this.imgs.length < superfish.b.suEnabled ){
        this.imgs[ this.imgs.length ] = img;
        if( !this.reqCount ){
            this.send();
        }
    }
};

superfish.publisher.send = function() {
    if (superfish.b.isPublisher && this.reqCount < superfish.b.suEnabled) {
        spsupport.api.validateSU( this.imgs[ this.reqCount++ ] );
    }
    else {
        superfish.util.bCloseEvent( document.getElementById("SF_CloseButton"), 2 );
        spsupport.p.prodPage.e = 1;
    }
};

superfish.publisher.fixSuPos = function(top) {
    return (this._fixSuPos ? this._fixSuPos(top) : top);
};

superfish.publisher.report = function(action) {
    if (this._report) {
        this._report(action);
    }
};





        
        
	
        
            superfish.b.inj( superfish.b.site + "js/sf_conduit.js?ver=" + superfish.b.appVersion , 1, 1 );

            

            

            

            // *8*
            
                superfish.sg = {
    sSite: 0,
    ancNode: 0,
    itemWidth: 98,
    init : function(data) {
        this.obj = sufio.eval(data);
        var prB = sufio.byId("productbox").parentNode;
        if (prB) {
            var box = sufio.coords(prB);             
            var anc = sufio.query(this.nodeType, prB)[1];

            var itemsNum = Math.min(parseInt(box.w/(this.itemWidth + 8)), this.obj.length);
            var html = "";
            for (var i = 0; i < itemsNum; i++) {
                html += this.getItemHtml(this.obj[i], i);
            }
            this.close();
            this.sg = sufio.place(this.create(html), anc, "after");
            spsupport.api.startDOMEnumeration();
        }
    },

    create : function(html) {
        return(
            "<div id = 'SF_SEARCHGET' style='width:100%; margin-bottom: 14px;position: relative;'>" +
                "<table cellpadding='0' cellspacing = '0' style = 'width: 100%;'><tr><td>Visual Search results</td>" +
                "<td style='text-align:right; color: #0E774A; font-size: 12px;'>Powered by <a href = '"+ superfish.b.psuSupportedByLink +"' target='_new' style='color: #0E774A;'>Superfish</a>&nbsp;&nbsp;&nbsp;<span id = 'SF_SG_CLOSE' style='cursor: pointer;' onclick='superfish.sg.sleep()'>[x]</span></td></tr></table>" +
                html +
            "</div>");
    },

    getItemHtml : function(item, index) {
        return(
            "<div id = 'SF_SG_RES" + index + "' style='margin-top: 7px;  overflow: hidden; text-align: left; width: "+ this.itemWidth +"px;padding-right: 8px; text-align: left; display: inline-block; vertical-align: top; font-family: arial,sans-serif; font-size: small; line-height: 1.2;'>" +
                "<a href='"+ item.merchURL +"' target='_blank' style = 'display: block; width: 82px; height: 82px; text-align: center; vertical-align: middle; border:1px solid #1111CC;'>" +
                    "<img src = "+ item.imagePath +" style='width:80px; height:80px; display: inline-block; border: none; padding: 1px;' >" +
                "</a>" +
                "<a href='"+ item.merchURL +"' target='_new' style='display:block;padding-top: 3px;max-height:48px; overflow: hidden;'>"+ item.title +"</a>" +
                 "<div style = 'font-weight: bold;'>" + item.price + "</div>"+
                "<a href='"+ item.merchURL +"' target='_new' style='display:block; color:#0E774A;text-decoration: none; width: 90px; overflow: hidden;'>"+item.merchantName+"</a>" +
            "</div>"
        );
    },

    close : function() {
        var sg = sufio.byId( "SF_SEARCHGET" );
        if( sg ){
            sufio.destroy(sg);
        }
    },


    sleep : function() { 
        var imUrlDef = spsupport.p.imgPath;
        var bEvt = " onmouseover='superfish.sg.sgBtnEvt(this,1)' onmouseout='superfish.sg.sgBtnEvt(this,0)' onmousedown='superfish.sg.sgBtnEvt(this,2)' onmouseup='superfish.sg.sgBtnEvt(this,4)' ";
        var prompt = "<div id='SF_SG_PAUSE_PROMPT' style='width:220px;height:76px;background:url(" + imUrlDef + "bgPSgP.png);position: absolute; top: 20px; right: -37px; z-index:10; font-size:12px;text-align:center;padding-top:18px;line-height:14px;'>" + superfish.b.partnerSgPausePopup +
                "       <table border='0' cellspacing='0' cellpadding = '0' style='margin:1px auto 0;padding:0;'><tbody><tr><td style='padding:0;'><div id='SF_SG_B_PAUSE_OK' style='margin:2px;width:57px;height:20px;background:url(" + imUrlDef + "bPreSu.png) 0px -20px no-repeat;' " + bEvt + "></div></td>" +
                "       <td style='padding:0;'><div id='SF_SG_B_CLOSE' style='margin:2px;width:57px;height:20px;background:url(" + imUrlDef + "bPreSu.png) 0px 0px no-repeat;' " + bEvt + "></div></td></tr></tbody></table>" +
                "</div>"
        this.pr = sufio.byId( "SF_SG_PAUSE_PROMPT" );
        if (this.pr) {
            this.pr.style.display = 'block';
        }
        else {
            this.pr = sufio.place( prompt, this.sg);
        }
    },

    sgBtnEvt : function (btn, evt) {
        var xP = ( evt == 0 || evt == 4  ? "0" : ( evt == 1 ? "-57" : "-114" ) ) + "px ";
        var yP = (btn.id == "SF_SG_B_PAUSE_OK" ? -20 : 0 ) + "px";
        btn.style.backgroundPosition = xP + yP;
        if( evt == 4){
            this.pr.style.display = "none";
            if (btn.id == "SF_SG_B_PAUSE_OK") {
                superfish.util.sendRequest("{\"cmd\": 2, \"type\": 2 }");
                this.close();
                spsupport.api.startDOMEnumeration();
            }
        }
    }
};


            

    }
}

