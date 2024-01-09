# Integrar pug a express
1. Instalar pug
```
npm i -S pug
```

2. Agregar pug en el servidor, llamarlo por ejemlo: `server.js`
```javascript
const express = require('express')
const app = express()

app.set('port', process.env.PORT || 3000)
app.set('views', './views')
app.set('view engine', 'pug')

app.get('/', (req, res) => {
	res.render('index', { title: 'Hey', message: 'Test'})
})

app.listen(app.get('port'), () => {
	console.log('Running')
})
```

3. Crear el archivo .pug en la carpeta `views` y llamarlo `index.pug`
```pug
html
	head
		title=title
	body
		h1=message
```

4. Correr el servidor
```
node server
```
