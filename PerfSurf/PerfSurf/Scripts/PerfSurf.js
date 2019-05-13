(function () {
    var perfHub = $.connection.PerfHub;
    $.connection.logging = true;
    $.connection.hub.start();

    var Model = function () {
        var self = this;
        self.message = ko.observable("");
        self.messages = ko.observableArray();
    }

    Model.prototype = {
        sendMessage: function () {
            var self = this;
            perfHub.server.send(self.message());
            self.message("");
        },
        addMessage: function(message) {
            var self = this;
            self.messages.push(message);
        }
    };

    var model = new Model();
    $(function() {
        ko.applyBindings(model);
    });

    perfHub.client.newMessage = function (message) {
        model.addMessage(message);
    };

}());