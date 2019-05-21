function HomeViewModel(app, dataModel) {
    var self = this;

    self.myHometown = ko.observable("");

    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.userInfoUrl,
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (data) {
                    self.myHometown('Your Hometown is : ' + data.hometown);
                }
            });
        });
        this.get('/', function () { this.app.runRoute('get', '#home'); });
    });

    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
    var candidateModel = {
        FirstName: ko.observable(''),
    LastName: ko.observable(''),
    Email: ko.observable(''),
    Experience: ko.observable(0),
    Technologies: ko.observableArray([]),
    TechnologyToAdd: ko.observable('')
};


candidateModel.Name = ko.dependentObservable(function () {
    return candidateModel.FirstName() +
        " " + candidateModel.LastName();
});



candidateModel.addTechnology = function () {
    if (candidateModel.TechnologyToAdd() !== '') {
        candidateModel.Technologies.push(candidateModel.TechnologyToAdd());
        candidateModel.TechnologyToAdd('');
    }
};
ko.applyBindings(candidateModel);


candidateModel.addCandidate = function () {
    $.ajax({
        url: "/Home/Create/",
        type: 'post',
        data: ko.toJSON(this),
        contentType: 'application/json',
        success: function (result) {
            alert(result);
        }
    });
};

