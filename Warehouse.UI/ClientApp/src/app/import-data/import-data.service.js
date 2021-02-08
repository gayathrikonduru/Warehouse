"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UploadDataService = void 0;
var http_1 = require("@angular/common/http");
var API_URL = "https://localhost:44314/api/fileupload/processFile";
var httpOptions = {
    headers: new http_1.HttpHeaders({
        'Content-Type': 'application/json'
    })
};
//@Injectable({
//  providedIn: 'root'
//})
var UploadDataService = /** @class */ (function () {
    function UploadDataService(http) {
        this.http = http;
    }
    UploadDataService.prototype.uploadFile = function (data) {
        return this.http.post(API_URL, data, httpOptions);
    };
    return UploadDataService;
}());
exports.UploadDataService = UploadDataService;
//# sourceMappingURL=upload-data.service.js.map