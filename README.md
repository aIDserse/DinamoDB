# DinamoDB (I know It's called DynamoDB)
School project consisting in embedded data handling in .net with Amazon DynamoDB<br>
The program uses an Arduino to collect sensor devices, convert them into a Json and send them into the program.<br>
To use it you need an Arduino and an <a href="https://signin.aws.amazon.com/signin?redirect_uri=https%3A%2F%2Faws.amazon.com%2Fmarketplace%2Fmanagement%2Fsignin%3Fstate%3DhashArgs%2523%26isauthcode%3Dtrue&client_id=arn%3Aaws%3Aiam%3A%3A015428540659%3Auser%2Faws-mp-seller-management-portal&forceMobileApp=0&code_challenge=4tjUEaavKx8zfGfJdU2be5SiOiG4SjgWkeBohDQ1Ss0&code_challenge_method=SHA-256">Amazon AWS account</a><br>
The program uses a specific custom class simply named "Data.cs" and Arduino UNO to retrieve and handle the data, with Light, Water Level and DHT11 sensors. <br>
If you want to use a different type of Arduino or a different class you'll obviously have to edit it, but the methods are pretty universal and only the properties names will have to be changed.<br>
# Contributors
<table>
  <tbody>
    <tr>            
      <td align="center"><a href="https://github.com/Daxxlol"><img src="https://avatars.githubusercontent.com/u/95642520?v=4" width="100px;" alt="Daxxlol"/><br />
      <b>Daxxlol</b></a><br/ ><sub><a href="https://github.com/aIDserse/DinamoDB/blob/main/Report/DinamoDB%20report.pdf" title="Report">Report Writing and code commenting</a></sub></td> 
      <td align="center"><a href="https://github.com/Thoooms"><img src="https://avatars.githubusercontent.com/u/106381511?v=4" width="100px;" alt="Thoooms"/><br />
      <b>Thoooms</b></a><br/ ><sub><a href="https://github.com/aIDserse/DinamoDB/blob/main/ProgettoDinamoDB/Arduino%20Sketch/Sketch.ino" title="Arduino skecth and communication">Arduino skecth and communication</a></sub></td> 
      <td align="center"><a href="https://github.com/aIDserse"><img src="https://avatars.githubusercontent.com/u/65368677?v=4" width="100px;" alt="aIDserse"/><br />
      <b>aIDserse</b></a><br/ ><sub><a href="https://github.com/aIDserse/DinamoDB" title="DynamoDB handling and C# side">DynamoDB handling and C# side</a></sub></td>
    </tr>
  </tbody>
</table>
