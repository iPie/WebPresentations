
		define(["vendor/amd/Handlebars"], function(Handlebars) {
			return {
		
"ComponentContainer": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, stack2, foundHelper, tmp1, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;

function program1(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "scale(";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1['x']);
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale.x", { hash: {} }); }
  buffer += escapeExpression(stack1) + ", ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1['y']);
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale.y", { hash: {} }); }
  buffer += escapeExpression(stack1) + ")";
  return buffer;}

function program3(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "scale(";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale", { hash: {} }); }
  buffer += escapeExpression(stack1) + ")";
  return buffer;}

function program5(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "scale(";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale", { hash: {} }); }
  buffer += escapeExpression(stack1) + ")";
  return buffer;}

  buffer += "<div class=\"componentContainer\" style=\"top: ";
  foundHelper = helpers['y'];
  stack1 = foundHelper || depth0['y'];
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "y", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px; left: ";
  foundHelper = helpers['x'];
  stack1 = foundHelper || depth0['x'];
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "x", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px;\n-webkit-transform: ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack2 = helpers['if'];
  tmp1 = self.program(1, program1, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += ";\n-moz-transform: ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack2 = helpers['if'];
  tmp1 = self.program(3, program3, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += ";\ntransform: ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack2 = helpers['if'];
  tmp1 = self.program(5, program5, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\">\n";
  stack1 = depth0;
  stack1 = self.invokePartial(partials.TransformContainer, 'TransformContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  return buffer;}

),
"Image": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, foundHelper, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;


  stack1 = depth0;
  stack1 = self.invokePartial(partials.ComponentContainer, 'ComponentContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n<img src=\"";
  foundHelper = helpers.src;
  stack1 = foundHelper || depth0.src;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "src", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\"></img>\n</div>\n</div>";
  return buffer;}

),
"ImpressTemplate": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers;
  var buffer = "", stack1, stack2, foundHelper, tmp1, self=this, functionType="function", blockHelperMissing=helpers.blockHelperMissing, helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;

function program1(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program3(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "\n";
  foundHelper = helpers.attributes;
  stack1 = foundHelper || depth0.attributes;
  tmp1 = self.program(4, program4, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack1 === functionType) { stack1 = stack1.call(depth0, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n</div>\n";
  return buffer;}
function program4(depth0,data) {
  
  var buffer = "", stack1, stack2;
  buffer += "\n<div class=\"step\" data-x=\"";
  foundHelper = helpers['x'];
  stack1 = foundHelper || depth0['x'];
  foundHelper = helpers.scaleX;
  stack2 = foundHelper || depth0.scaleX;
  tmp1 = self.program(5, program5, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\" data-y=\"";
  foundHelper = helpers['y'];
  stack1 = foundHelper || depth0['y'];
  foundHelper = helpers.scaleY;
  stack2 = foundHelper || depth0.scaleY;
  tmp1 = self.program(7, program7, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\" ";
  foundHelper = helpers.rotateX;
  stack1 = foundHelper || depth0.rotateX;
  stack2 = helpers['if'];
  tmp1 = self.program(9, program9, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "  ";
  foundHelper = helpers.rotateY;
  stack1 = foundHelper || depth0.rotateY;
  stack2 = helpers['if'];
  tmp1 = self.program(12, program12, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.rotateZ;
  stack1 = foundHelper || depth0.rotateZ;
  stack2 = helpers['if'];
  tmp1 = self.program(15, program15, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers['z'];
  stack1 = foundHelper || depth0['z'];
  stack2 = helpers['if'];
  tmp1 = self.program(18, program18, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.impScale;
  stack1 = foundHelper || depth0.impScale;
  stack2 = helpers['if'];
  tmp1 = self.program(20, program20, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += ">\n<div style=\"width: 1024px; height: 768px\">\n";
  foundHelper = helpers.components;
  stack1 = foundHelper || depth0.components;
  tmp1 = self.program(22, program22, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack1 === functionType) { stack1 = stack1.call(depth0, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n</div>\n";
  return buffer;}
function program5(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program7(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program9(depth0,data) {
  
  var buffer = "", stack1, stack2;
  buffer += "data-rotate-x=\"";
  foundHelper = helpers.rotateX;
  stack1 = foundHelper || depth0.rotateX;
  foundHelper = helpers.toDeg;
  stack2 = foundHelper || depth0.toDeg;
  tmp1 = self.program(10, program10, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\"";
  return buffer;}
function program10(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program12(depth0,data) {
  
  var buffer = "", stack1, stack2;
  buffer += "data-rotate-y=\"";
  foundHelper = helpers.rotateY;
  stack1 = foundHelper || depth0.rotateY;
  foundHelper = helpers.toDeg;
  stack2 = foundHelper || depth0.toDeg;
  tmp1 = self.program(13, program13, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\"";
  return buffer;}
function program13(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program15(depth0,data) {
  
  var buffer = "", stack1, stack2;
  buffer += "data-rotate-z=\"";
  foundHelper = helpers.rotateZ;
  stack1 = foundHelper || depth0.rotateZ;
  foundHelper = helpers.toDeg;
  stack2 = foundHelper || depth0.toDeg;
  tmp1 = self.program(16, program16, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\"";
  return buffer;}
function program16(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program18(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "data-z=\"";
  foundHelper = helpers['z'];
  stack1 = foundHelper || depth0['z'];
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "z", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\"";
  return buffer;}

function program20(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "data-scale=\"";
  foundHelper = helpers.impScale;
  stack1 = foundHelper || depth0.impScale;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "impScale", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\"";
  return buffer;}

function program22(depth0,data) {
  
  var buffer = "", stack1, stack2;
  buffer += "\n";
  stack1 = depth0;
  foundHelper = helpers.renderComponent;
  stack2 = foundHelper || depth0.renderComponent;
  tmp1 = self.program(23, program23, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n";
  return buffer;}
function program23(depth0,data) {
  
  var buffer = "";
  return buffer;}

function program25(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "\n<script>\nvar interval = ";
  stack1 = depth0;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, ".", { hash: {} }); }
  buffer += escapeExpression(stack1) + ";\nif (interval >= 1000) {\n    setInterval(function() {\n        impress().next();\n    }, interval);\n}\n</script>\n";
  return buffer;}

  buffer += "<head>\n<meta charset=\"utf-8\" />\n<meta name=\"viewport\" content=\"width=1024\" />\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\n<title>Preview</title>\n\n<meta name=\"description\" content=\"TODO\" />\n<meta name=\"author\" content=\"TODO\" />\n\n<style>\n.componentContainer {\n    position: absolute;\n    -webkit-transform-origin: 0 0;\n    -moz-transform-origin: 0 0;\n    transform-origin: 0 0;\n}\n\n.bg {\n    width: 100%;\n    height: 100%;\n}\n</style>\n<link href=\"preview_export/css/main.css\" rel=\"stylesheet\" />\n<link href='preview_export/css/web-fonts.css' rel='stylesheet' type='text/css'>\n\n<link rel=\"shortcut icon\" href=\"favicon.png\" />\n<link rel=\"apple-touch-icon\" href=\"apple-touch-icon.png\" />\n</head>\n  <body class=\"impress-not-supported\">\n\n<!-- This is a work around / hack to get the user's browser to download the fonts \n if they decide to save the presentation. -->\n<div style=\"visibility: hidden; width: 0px; height: 0px\">\n<img src=\"/Content/fonts/Lato-Bold.woff\" />\n<img src=\"/Content/fonts/HammersmithOne.woff\" />\n<img src=\"/Content/fonts/Gorditas-Regular.woff\" />\n<img src=\"/Content/fonts/FredokaOne-Regular.woff\" />\n<img src=\"/Content/fonts/Ubuntu.woff\" />\n<img src=\"/Content/fonts/Ubuntu-Bold.woff\" />\n<img src=\"/Content/fonts/PressStart2P-Regular.woff\" />\n<img src=\"/Content/fonts/Lato-BoldItalic.woff\" />\n<img src=\"/Content/fonts/brilFatface-Regular.woff\" />\n<img src=\"/Content/fonts/Lato-Regular.woff\" />\n</div>\n\n<div class=\"fallback-message\">\n    <p>Your browser <b>doesn't support the features required</b> by impress.js, so you are presented with a simplified version of this presentation.</p>\n    <p>For the best experience please use the latest <b>Chrome</b>, <b>Safari</b> or <b>Firefox</b> browser.</p>\n</div>\n <a href=\"#\">Preview mode</a> \n  \n<div class=\"bg\" style=\"";
  foundHelper = helpers.background;
  stack1 = foundHelper || depth0.background;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1.styles);
  foundHelper = helpers.extractBG;
  stack2 = foundHelper || depth0.extractBG;
  tmp1 = self.program(1, program1, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack2 === functionType) { stack1 = stack2.call(depth0, stack1, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack2, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\">\n<div id=\"impress\">\n\n";
  foundHelper = helpers.slides;
  stack1 = foundHelper || depth0.slides;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1.models);
  tmp1 = self.program(3, program3, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack1 === functionType) { stack1 = stack1.call(depth0, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n\n</div>\n<div class=\"hint\">\n    <p>Use a spacebar or arrow keys to navigate</p>\n</div>\n<script>\nif (\"ontouchstart\" in document.documentElement) { \n    document.querySelector(\".hint\").innerHTML = \"<p>Tap on the left or right to navigate</p>\";\n}\n</script>\n\n";
  foundHelper = helpers.interval;
  stack1 = foundHelper || depth0.interval;
  tmp1 = self.program(25, program25, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  if(foundHelper && typeof stack1 === functionType) { stack1 = stack1.call(depth0, tmp1); }
  else { stack1 = blockHelperMissing.call(depth0, stack1, tmp1); }
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n</div>\n<script type=\"text/javascript\" src=\"/scripts/preview/impress.js\">\n</script>\n<script>\nif (!window.impressStarted) {\n    startImpress(document, window);\n    impress().init();   \n}\n</script>\n</body>";
  return buffer;}

),
"SVGContainer": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, foundHelper, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;


  buffer += "<div class=\"componentContainer\" style=\"top: ";
  foundHelper = helpers['y'];
  stack1 = foundHelper || depth0['y'];
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "y", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px; left: ";
  foundHelper = helpers['x'];
  stack1 = foundHelper || depth0['x'];
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "x", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px; width: ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1.width);
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale.width", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px; height: ";
  foundHelper = helpers.scale;
  stack1 = foundHelper || depth0.scale;
  stack1 = (stack1 === null || stack1 === undefined || stack1 === false ? stack1 : stack1.height);
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "scale.height", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px;\">\n";
  stack1 = depth0;
  stack1 = self.invokePartial(partials.TransformContainer, 'TransformContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  return buffer;}

),
"SVGImage": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, foundHelper, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;


  stack1 = depth0;
  stack1 = self.invokePartial(partials.SVGContainer, 'SVGContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n<img src=\"";
  foundHelper = helpers.src;
  stack1 = foundHelper || depth0.src;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "src", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\" style=\"width: 100%; height: 100%\"></img>\n</div>\n</div>";
  return buffer;}

),
"TextBox": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, foundHelper, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;


  stack1 = depth0;
  stack1 = self.invokePartial(partials.ComponentContainer, 'ComponentContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n<div style=\"font-family: ";
  foundHelper = helpers.family;
  stack1 = foundHelper || depth0.family;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "family", { hash: {} }); }
  buffer += escapeExpression(stack1) + "; font-size: ";
  foundHelper = helpers.size;
  stack1 = foundHelper || depth0.size;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "size", { hash: {} }); }
  buffer += escapeExpression(stack1) + "px;\n			font-weight: ";
  foundHelper = helpers.weight;
  stack1 = foundHelper || depth0.weight;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "weight", { hash: {} }); }
  buffer += escapeExpression(stack1) + "; font-style: ";
  foundHelper = helpers.style;
  stack1 = foundHelper || depth0.style;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "style", { hash: {} }); }
  buffer += escapeExpression(stack1) + "; color: #";
  foundHelper = helpers.color;
  stack1 = foundHelper || depth0.color;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "color", { hash: {} }); }
  buffer += escapeExpression(stack1) + ";\n			text-decoration: ";
  foundHelper = helpers.decoration;
  stack1 = foundHelper || depth0.decoration;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "decoration", { hash: {} }); }
  buffer += escapeExpression(stack1) + "; text-align: ";
  foundHelper = helpers.align;
  stack1 = foundHelper || depth0.align;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "align", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\">\n";
  foundHelper = helpers.text;
  stack1 = foundHelper || depth0.text;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "text", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\n</div>\n</div>\n</div>";
  return buffer;}

),
"TransformContainer": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers;
  var buffer = "", stack1, stack2, foundHelper, tmp1, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;

function program1(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "rotate(";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "rotate", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program3(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewX(";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewX", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program5(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewY(";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewY", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program7(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "rotate(";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "rotate", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program9(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewX(";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewX", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program11(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewY(";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewY", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program13(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "rotate(";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "rotate", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program15(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewX(";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewX", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

function program17(depth0,data) {
  
  var buffer = "", stack1;
  buffer += "skewY(";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "skewY", { hash: {} }); }
  buffer += escapeExpression(stack1) + "rad)";
  return buffer;}

  buffer += "<div class=\"transformContainer\" style=\"-webkit-transform: ";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  stack2 = helpers['if'];
  tmp1 = self.program(1, program1, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  stack2 = helpers['if'];
  tmp1 = self.program(3, program3, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  stack2 = helpers['if'];
  tmp1 = self.program(5, program5, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "; -moz-transform: ";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  stack2 = helpers['if'];
  tmp1 = self.program(7, program7, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  stack2 = helpers['if'];
  tmp1 = self.program(9, program9, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  stack2 = helpers['if'];
  tmp1 = self.program(11, program11, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "; transform: ";
  foundHelper = helpers.rotate;
  stack1 = foundHelper || depth0.rotate;
  stack2 = helpers['if'];
  tmp1 = self.program(13, program13, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewX;
  stack1 = foundHelper || depth0.skewX;
  stack2 = helpers['if'];
  tmp1 = self.program(15, program15, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += " ";
  foundHelper = helpers.skewY;
  stack1 = foundHelper || depth0.skewY;
  stack2 = helpers['if'];
  tmp1 = self.program(17, program17, data);
  tmp1.hash = {};
  tmp1.fn = tmp1;
  tmp1.inverse = self.noop;
  stack1 = stack2.call(depth0, stack1, tmp1);
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\">";
  return buffer;}

),
"Video": Handlebars.template(function (Handlebars,depth0,helpers,partials,data) {
  helpers = helpers || Handlebars.helpers; partials = partials || Handlebars.partials;
  var buffer = "", stack1, foundHelper, self=this, functionType="function", helperMissing=helpers.helperMissing, undef=void 0, escapeExpression=this.escapeExpression;


  stack1 = depth0;
  stack1 = self.invokePartial(partials.ComponentContainer, 'ComponentContainer', stack1, helpers, partials);;
  if(stack1 || stack1 === 0) { buffer += stack1; }
  buffer += "\n<video controls>\n	<source src=\"";
  foundHelper = helpers.src;
  stack1 = foundHelper || depth0.src;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "src", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\" type=\"";
  foundHelper = helpers.videoType;
  stack1 = foundHelper || depth0.videoType;
  if(typeof stack1 === functionType) { stack1 = stack1.call(depth0, { hash: {} }); }
  else if(stack1=== undef) { stack1 = helperMissing.call(depth0, "videoType", { hash: {} }); }
  buffer += escapeExpression(stack1) + "\"></source>\n</video>\n</div>\n</div>";
  return buffer;}

)
}});