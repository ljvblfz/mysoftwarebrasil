/**
	Copyright (c) 2011 Darvin da Silveira

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
 */
(function( $ ){

	$.fn.ep = function( options ) {

		var settings = {
		  'content' 	: '',
		  'trigger' 	: 'scroll',
		  'message'		: 'Carregando...',
		  'results' 	: 1,
		  'beforeLoad'  : function(){void(0)},
		  'onLoad'		: function(){void(0)},
		  'onEnd' 		: function(){void(0)},
		  'data'		: {}
		};
		var container = this;
		var counter = 0;
		var message = $(settings.trigger).text();

		var showContent = function(){
			settings.beforeLoad();
			$(settings.trigger).text(settings.message);
			$.ajax({
				type : 'POST',
				url : settings.content,
				data: options.data,
				success : function(data){
					$(container).append(data);
					$(settings.trigger).text(message);
					if(data != ''){
						settings.onLoad();
						$(settings.trigger).show();
					}else{
						$(settings.trigger).hide();
						settings.onLoad();
						settings.onEnd();
					}
				}
			});
		}

		return this.each(function(){
		    if ( options ) {
				$.extend( settings, options );
			}
			message = $(settings.trigger).text();
			counter = counter + settings.results;
			options.data[2] = {'name' : 'counter','value' : counter};
			options.data[3] = {'name' : 'results','value' : settings.results};
			//container.load(settings.content, options.data);

			if(settings.trigger == 'scroll'){
				container.bind('scroll', function(){
					if(container[0].scrollHeight - container.scrollTop() <= container[0].offsetHeight){
						showContent();
					}
				})
			}else{
				//$(settings.trigger).bind('click', function(){
					showContent();
				//});
			}
		});
	};
})( jQuery );