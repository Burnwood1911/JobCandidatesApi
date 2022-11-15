# Job Candidates API

A simple Rest API for storing Job Candidates.

## Usage

- Make a POST Request to the endpoint

```shell
https://{IP}:{PORT}/candidate
```
- The Body of Request in JSON format

```shell
{
  "firstname": "alex",
  "lastname": "pauql",
  "phonenumber": "0628646309",
  "email": "kalebdfsf@gmail.com",
  "calltime": "10:00 - 09:00",
  "linkedin": "www.linkedin.com",
  "github": "www.github.com",
  "comment": "this is a comment"
}
```
- Succesful Response
```js
Task completed succesfully
```

- Failure Response
```js
Error Task Failed.
```

## Credits
- [Alex Rossi](https://github.com/burnwood1911)
## License
This project is licensed under the [MIT](LICENSE.md) License.