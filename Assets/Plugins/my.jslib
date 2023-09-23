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
});