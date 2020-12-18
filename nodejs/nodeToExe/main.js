module.exports = filePath =>
	JSON.stringify(JSON.parse(require('fs').readFileSync(filePath).toString()), false, 3)