mergeInto(LibraryManager.library, {

    InitExtern: function(){
        initSDK();
    },

    SaveExtern: function(date){
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        console.log(myobj);
        player.setData(myobj);
    },

    LoadExtern: function(){
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            console.log(myJSON);
            myGameInstance.SendMessage('Yandex', 'LoadData', myJSON);
        });
    },

    GetLangExtern: function () 
    {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        
        return buffer;
    },
});