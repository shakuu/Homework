<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:students="http://www.w3.org/TR/html4/unique/name"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <h1>Catalogue</h1>
          <xsl:for-each select="/catalogue/album" >
            <ul bgcolor="white">
              <li>
                <xsl:value-of select="name">
                </xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="artist">
                </xsl:value-of>
              </li>
            </ul>
          </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
