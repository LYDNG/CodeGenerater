
var treeEditor = null;
var codeEditor = null;

var app = {};
app.CodeToTree = function () {
    try {
        treeEditor.set(codeEditor.get());
    }
    catch (err) {
        //app.notify.showError(app.formatError(err));
    }
};
app.treeToCode = function () {
    try {
        codeEditor.set(treeEditor.get());
    }
    catch (err) {
        //app.notify.showError(app.formatError(err));
    }
};
app.load = function () {
    try {
        // notification handler
        app.notify = new Notify();

        // Store whether tree editor or code editor is last changed
        app.lastChanged = undefined;

        // code editor
        var container = document.getElementById("codeEditor");
        codeEditor = new jsoneditor.JSONEditor(container, {
            mode: 'code',
            change: function () {
                app.lastChanged = codeEditor;
            },
            error: function (err) {
                //app.notify.showError(app.formatError(err));
            }
        });

        // tree editor
        container = document.getElementById("treeEditor");
        treeEditor = new jsoneditor.JSONEditor(container, {
            mode: 'tree',
            change: function () {
                app.lastChanged = treeEditor;
            },
            error: function (err) {
                //app.notify.showError(app.formatError(err));
            }
        });
        // TODO: automatically synchronize data of code and tree editor? (tree editor should keep its state though)

        // splitter
        app.splitter = new Splitter({
            container: document.getElementById('drag'),
            change: function () {
                app.resize();
            }
        });

        // button Code-to-Tree
        var toTree = document.getElementById('toTree');
        toTree.onclick = function () {
            this.focus();
            app.CodeToTree();
        };

        // button Tree-to-Code
        var toCode = document.getElementById('toCode');
        toCode.onclick = function () {
            this.focus();
            app.treeToCode();
        };

        // web page resize handler
        jsoneditor.util.addEventListener(window, 'resize', app.resize);

        // set focus on the code editor
        codeEditor.focus();

        // enforce FireFox to not do spell checking on any input field
        document.body.spellcheck = false;
    } catch (err) {
        //app.notify.showError(err);
    }
};

app.openCallback = function (err, data) {
    if (!err) {
        if (data != null) {
            codeEditor.setText(data);
            try {
                var json = jsoneditor.util.parse(data);
                treeEditor.set(json);
            }
            catch (err) {
                treeEditor.set({});
                //app.notify.showError(app.formatError(err));
            }
        }
    }
    else {
        //app.notify.showError(err);
    }
};

app.formatError = function (err) {
    return '<pre class="error">' + err.toString() + '</pre>';
};



app.resize = function () {
    var domMenu = document.getElementById('menu');
    var domTreeEditor = document.getElementById('treeEditor');
    var domCodeEditor = document.getElementById('codeEditor');
    var domSplitter = document.getElementById('splitter');
    var domSplitterButtons = document.getElementById('buttons');
    var domSplitterDrag = document.getElementById('drag');
    var domAd = document.getElementById('ad');

    var margin = 15;
    var width = (window.innerWidth || document.body.offsetWidth ||
        document.documentElement.offsetWidth);
    var adWidth = domAd ? domAd.clientWidth : 0;
    if (adWidth) {
        width -= (adWidth + margin);
    }

    if (app.splitter) {
        app.splitter.setWidth(width);

        // calculate horizontal splitter position
        var value = app.splitter.getValue();
        var showCodeEditor = (value > 0);
        var showTreeEditor = (value < 1);
        var showButtons = showCodeEditor && showTreeEditor;
        domSplitterButtons.style.display = showButtons ? '' : 'none';

        var splitterWidth = domSplitter.clientWidth;
        var splitterLeft;
        if (!showCodeEditor) {
            // code editor not visible
            splitterLeft = 0;
            domSplitterDrag.innerHTML = '&rsaquo;';
            domSplitterDrag.title = '向右拖动展示代码编辑器';
        }
        else if (!showTreeEditor) {
            // tree editor not visible
            splitterLeft = width * value - splitterWidth;
            domSplitterDrag.innerHTML = '&lsaquo;';
            domSplitterDrag.title = '向左拖动展示树形编辑器。';
        }
        else {
            // both tree and code editor visible
            splitterLeft = width * value - splitterWidth / 2;

            // TODO: find a character with vertical dots that works on IE8 too, or use an image
            var isIE8 = (jsoneditor.util.getInternetExplorerVersion() == 8);
            domSplitterDrag.innerHTML = (!isIE8) ? '&#8942;' : '|';
            domSplitterDrag.title = '向左或向右拖动修改界面的宽度。';
        }

        // resize code editor
        domCodeEditor.style.display = (value == 0) ? 'none' : '';
        domCodeEditor.style.width = Math.max(Math.round(splitterLeft), 0) + 'px';
        codeEditor.resize();

        // resize the splitter
        domSplitterDrag.style.height = (domSplitter.clientHeight -
            domSplitterButtons.clientHeight - 2 * margin -
            (showButtons ? margin : 0)) + 'px';
        domSplitterDrag.style.lineHeight = domSplitterDrag.style.height;

        domTreeEditor.style.display = (value == 1) ? 'none' : '';
        domTreeEditor.style.left = Math.round(splitterLeft + splitterWidth) + 'px';
        domTreeEditor.style.width = Math.max(Math.round(width - splitterLeft - splitterWidth - 2), 0) + 'px';
    }

    // align main menu with ads
    if (domMenu) {
        if (adWidth) {
            domMenu.style.right = (margin + (adWidth + margin)) + 'px';
        }
        else {
            domMenu.style.right = margin + 'px';
        }
    }
};
