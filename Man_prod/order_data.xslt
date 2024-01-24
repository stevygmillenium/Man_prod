<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="ArrayOfItem">
        <!--<xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>-->
		<table border="1">
			<xsl:for-each select="Item">
				<tr>
					<td>
						<xsl:value-of select="Id"/>
					</td>
					<td>
						<xsl:value-of select="Name"/>
					</td>
					<td>
						<xsl:value-of select="price"/>
					</td>
					<td>
						<xsl:value-of select="quantity"/>
					</td>
				</tr>
			</xsl:for-each>
		</table>
    </xsl:template>
</xsl:stylesheet>
