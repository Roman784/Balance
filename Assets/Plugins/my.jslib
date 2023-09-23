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

    ShowFullscreenAdvExtern : function () 
    {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function(wasShown) {
                    myGameInstance.SendMessage('Yandex', 'AudioVolumeOn');
                    console.log ("adv close");
                },
                onOpen: function(open) {
                    myGameInstance.SendMessage('Yandex', 'AudioVolumeOff');
                    console.log ("adv open");
                },
                onError: function(error) {
                    myGameInstance.SendMessage('Yandex', 'AudioVolumeOn');
                    console.log ("adv error");
                }
            }
        })
    },

    ShowRewardedVideoExtern : function () 
    {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                  console.log('Video ad open.');
                },
                onRewarded: () => {
                  console.log('Rewarded!');
                },
                onClose: () => {
                  console.log('Video ad closed.');
                }, 
                onError: (e) => {
                  console.log('Error while open video ad:', e);
                }
            }
        })
    },

});