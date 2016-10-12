<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:students="http://www.w3.org/TR/html4/unique/name"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <body>
        <table>
          <xsl:for-each select="/students:students/students:student" >
            <ul bgcolor="white">
              <li>
                <xsl:value-of select="students:name">
                </xsl:value-of>
              </li>
              <li>
                <xsl:value-of select="students:course">
                </xsl:value-of>
              </li>
            </ul>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
