# starwarscharacterarchive
<svg>![.NET Core](https://github.com/czajaKorneliusz/starwarscharacterarchive/workflows/.NET%20Core/badge.svg)</svg>

## REST
<ul>
<li>
<b>GET</b>
/StarWarsCharacterArchive/Character
</li>
<li>
<b>POST</b>
/StarWarsCharacterArchive/Character
</li>
<li>
<b>GET</b>
/StarWarsCharacterArchive/Character/{name}
</li>
<li>
<b>PUT</b>
/StarWarsCharacterArchive/Character/{name}
</li>
<li>
<b>DELETE</b>
/StarWarsCharacterArchive/Character/{name}
</li>
</ul>

## Character

Character{
<br>name*	string
<br>episodes	[
nullable: true
string]
<br>planet	string
nullable: true
<br>friends	[
nullable: true
<br>Friend{
<br>id	integer($int32)
<br>name	string
nullable: true
<br>character	{
}
}]
}

## used technologies
<ul>
<li>.Net Core</li>
<li>Entity Framework</li>
<li>swagger</li>
<li>nUnit3</li>
<li>MSSql</li>
</ul>
