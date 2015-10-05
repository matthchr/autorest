var express = require('express');
var router = express.Router();
var util = require('util');
var utils = require('../util/utils')

var parameterGrouping = function(coverage) {
  coverage['postParameterGroupingOptionalParameters'] = 0;
  coverage['postParameterGroupingRequiredParameters'] = 0;

    router.post('/postRequired/:path', function(req, res, next) {
        if (req.body === 1234 && req.params.path === 'path' && 
            (req.get('header') === 'header' || req.get('header') === undefined) && 
            (req.query['query'] === '21' || req.query['query'] === undefined)) {
            coverage['postParameterGroupingRequiredParameters']++;
            res.status(200).end();
        } else {
            utils.send400(res, next, "Did not like the values in the req. Body: " + util.inspect(req.body) + 
                ", Path: " + req.params.path + ", header: " + req.get('header') + ", query: " + req.query['query']);
        }
    });

    router.post('/postOptional', function(req, res, next) {
        if ((req.get('header') === 'header' || req.get('header') === undefined) && 
            (req.query['query'] === '21' || req.query['query'] === undefined)) {
            coverage['postParameterGroupingOptionalParameters']++;
            res.status(200).end();
        } else {
            utils.send400(res, next, "Did not like the values in the req. header: " + req.get('header') + ", query: " + req.query['query']);
        }
    });    
}

parameterGrouping.prototype.router = router;

module.exports = parameterGrouping;