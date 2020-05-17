mergeInto(LibraryManager.library, {
    OpenLinkInTab: function(url) {
        window.open(Pointer_stringify(url), '_blank');
    }
});