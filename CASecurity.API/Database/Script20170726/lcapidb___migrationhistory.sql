-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: lcapidb
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201707260630220_initialsetforMySql','CASecurity.API.Migrations.Configuration','ã\0\0\0\0\0\0\Ì][o‹∏~/\–ˇ \Ãcëù±\„&H\r{ìqºu7æ \„}3dâ3¢ëf%Mb£\Ë/\ÎCRˇBI]yïxìFéd=\"˘ë<<<$\œ˘\ﬂ˛{Ú\À\„&tæÅ$\r\‚\Ëtr8=ò8 Úb?à÷ßì]∂˙\È\›‰óüˇ¸ßì˛\Ê\—˘R\Â;B˘`\…(=ù<d\Ÿˆx6KΩ∞q\”\È&í8çW\Ÿ‘ã73◊ègØ˛6;<ú1ÅXésÚie¡\‰?\‡\œEy`õ\Ì\‹2ˆAòñ\ﬂa\ 2GuÆ\‹\rH∑ÆN\'ã˘xª$»û¶Ûõã\Èe∞N\‹6*ù8Û0paÉñ \\M7ä\‚,O9˛úÇeñ\ƒ\—zπÖ\‹ˆi`æï¶†\Ï\∆qì]∂GØQèfM¡\n\ €•YºQ<<*I4£ãkzRìÒ$vˆÑzùÚt2\ﬂn\']\œÒ\"LPÜ\ƒg0WMa°WôÙ™\Ê\»8\Ë?òafªúF`ó%n¯ π\Ÿ›áÅ˜x∫çøÇ\Ë4⁄Ö!\ﬁ8\ÿ<òF|Äüníxí\Ï\ÈXïMæ\'Œå,7£\÷≈∞2Eè~\›\Ô+X∑{Çz\Ëg≠\≈ﬂª\—\◊KêxnîB°+\0»äprMúK˜Ò#à\÷\Ÿ\√\È˛9qŒÉG\‡W_J\‘\œQ\0\Á\",î%ª\ŒJn\\Ô´ªÓøûπ\Ô\' M{ØgsˆO¥\–\Õ\Œ\„d\”EI\Ï\ÔºbB˜\\\’“ç¸˜Òc\Ôı¸Jê˜iêqZû˝vë¶;\‡üπ∏\rö\È\‘¸n∏H\Áê˙\ﬂ\Ír\Ô\„8n§<ï	Ä5∂4£\Ôd\÷\„VçuYçó~yB\€¬í\Ã\ÔgZ\\πﬂÇu\Œ¥T\ﬁn°H˛\¬b7Ùlãù¡wEÆÛ$\ﬁ|äCä\ÕÚƒªeºK<\‘Xî\„\÷M\÷ 3\‡k=~~Y|<»éa\…=\‹v!\ \\/ªÅLGë´Òd‘∞Ùa*Ωå\ÔÉ\\≈Ω\◊:é’≥M˛U2J,\Ô∞,§lR∏\‚K6í}˙\Î˘k˘ò\≈\Ë˚OãHä∞$åCöH\œ\€I\'\„µ˙º≠Jæ¨yã\ËΩ\ 	¶*\ﬁ)§ú~g ÉKk\ÔLô◊Ö\÷\À5I≥Y~æ]<∏a±Å:≥ë\Â_ÀÅoÅ\ÿ~¡\–\0µ†ïoıóõ¿ˇgê3˙_Y*\ŒÃô´˜\ÍÚZ\nïë\È2ÉA\Èo\\yò_\‹0\—\nf•Ö5öúäLZ.}ø\Ô@öi-ÄM\Ÿ&èÚ%∞\ÏΩ1≥î8-Ñem{]\n}êBg∞6¶ª¨\Ô¿\Ê\Èˆ\nd”™‡¥Ä<G\“\Ì{ú|ù‚àØ\Èr\róæñ\Â“£\√˚\’—ª7o]ˇ\Ë\Ì_¡—õ\·9ñ3ZáØ\ﬂIçñ\›\„\’\Î7o≠\‘*<ÙNÛïãs\‡\«\«˚Æ\Ã\÷˙\ŸT\Ê\‡\œ\…bt¯Øî}∂ÆP\«\œ⁄®•,{s≥¢\ÈÃÑ™ä°gC\’\ﬁ~\Îï\Ê8DÜb_¨µt\≈_\÷ÍΩÑ\⁄ıø#Üt\ÌA⁄åW06\…w\ƒÚQò©ñÅïò\Á¨™!\Ôö0\Ó\À\‚Zãg`#E\Ìpı≤7µ\√’çGVvGkF¸mIØ≠XÛ0 èºÅ∑\¬ﬁ∏i∫çìl¯\⁄\ÌZ”®*Z≠\›^™Na{7ò™ó\Ô`xp\≈≈îÆ}õ1\r≥≥03ï˙\‚>\\1oí ˆçuäZ©˛.ãÆ\‚\Î\’<\À¿f[O\Óã(;zmr\Î\‘À∂≠ÿå\Ÿﬂ∫\—\'\‹\ÓMû\÷\÷\r.!öU∞\ÌV\À\–x∂õ∏\·ûπÙ∂†áë®eG´ Ÿò´¨\—B˚=N¸øª\ÈCˇb∑\‰(~7\€˛/U\‚\\\Ì6˜à˚á´\À\⁄\–\‹~è\œ]/ãì*eå˜1ˆæ∆ª\ÏCî\À\Ãœôß∫\‘\0Vö3˜<ê¶ÁêôÅøàwë\·r ±\Ô]∫\›`\√_4(izWemV~fπd\„≠mMÖL\…5µ\ *një£≥©e6’¶\"0πññ9\≈\r\Õ3t∂≥\»eMÕúèê}=s;~E≥\Ÿ\‚-íóPBÇ_A¥ºq\·\ﬁ2âöêë˚\ÿ,\‰√á*\Ìˇ\∆\’˜ˇ;\€UiÕÜ\\ÿü\r9\Ï¯gC\ﬁL¯˘[\‡£]â\ƒ\ÌKï\¬K\Â\Á_\Ït\œ9™eCO¢õCW>åMóyö\∆^ê\œŒ´£\‚≠\Ÿ|∏Ös:é}°üû¿nA6–Çõ{6°Y\Í::!»Ä3˜äg≥7ı\\ü%\"\Ïé/ﬂÆ˙∆¢iW˛˛ïl\Œ_òZ gÉ\ÕazR83É(cßAy¡\÷\rª\»Bî\\±Pg\Î*\Ëî3∞í2]]ó©õ~\Ï ∂£Æé\Zå.:ù\Ã0>\Îf?\ÃJømåy&˚$\„\r\»púXcD3¿\"À±\‘à\ﬂÿû\À2\€ﬁòåc\"\Z\€63ëf|Ic•AòÆ\≈8Ö”∞\∆\‰§Si\0&SB¶ræÖ\…@å(VÁäÜ]B∑€å>~ÖNé˚¡tz\»ΩL-£åLZLÅ6≠Ö®\…]*b\È\'µ”É\Ã\◊›â`Œñ\Á˜^&m;\≈ò∏\Ì$ëiÄ–ílà\…+\–U\…2\0≠∏\ZÉR\Z3ÉñG\ÍAî§\ÿî$…≥c\–BE);˛îærl\ÏI*Já\ﬂÚ¥íkºI\–cd¨Y\ËÚg\ÎAñ=\œ\ÓQ\"x‰ΩãÜ\Ì,ısi©\Í†YÅ/A\÷¿¶ßQw\‡~f\√C\≈O¿<Rô!&\È,\‹\÷\n\È\‰\œ\√\‹8Äi¥vÄ\‰v$^e√É¢-v\06\ÔÅx`¯K£.†\‚∆Ömq\Î\Í%-\⁄\0â\“Jõf0à‘ñY\ZÆK\nH07HâÆ@¥\Í2±ïj\Â6V∂∫¯kÖ-7,&Ñ¯SªtÅÉ\Â˙…°e£åˆ≥\Ó#PQ+£¥\ƒ\‡äv”ã&\Ÿ_IZ\‡û0¯Ñi\·dÙp	∫ª\ŒQüaBjtû˜*à%@óÜHVGÑu¢î.-ÑhQ\È`8âeLî≥2ñ6íJEµ\÷CBﬁµ–´[K¡-˙eL3ëUK0MÜä.É\ÍU;ë:Ù∆™:cùJï\\\Ô¶\Ô8≠r†6¢u¯P©\Íåu*ïÛ∫õHú#ù¬°ŒàD\‰ÃíÄ™\Ó)\Î≥Bùv2+óNfè¡\'ó\ÓvDkÃÉp˘\≈Yñ\ÓÉZ™;\‘\›3è†6}≤©k\ \‚\ƒ]*µp≠s$iv\ÊfÓΩãni˛Ü\…\∆=	ˆNUï\ÿ\·á\√jUeFó\Z\"_\ ˘Åâ=Gñ\Á∞{t\Õ-`\»-\n[\ A^ú\›\–M8∂6ã8\‹m\"ÒëX\\öæØƒë∫\Ó2≈®ÖéU|ëG®ù\‚ ıGyú\⁄\ﬂéSî\«)ûì\‡ \≈Ö\’râ.\’_ê0∏ˆ]≠ˆrãC\’\Âqàw78ë†\–.\÷S-\—B6YªyAÃú˙´_–Æ≥°Y‹ì%E#xu)ƒ§Dy¶≤#\Î≈é∫\–k/ﬁüÙ\„I=5ë¸‘ìùÚífèºcìg4ye(1_\À\Ã\◊{´\„€ïlì¨â]øÉ\¬\◊94kh<\n´h≤¸±2H\œn€´Ç¡ä<Wsyë˚A%\ZÅ><\«=ÔãüM\ÕÌëù\ŸT\ﬂ8©\œ&q\—~f\ÊΩ¡>\Àc˛Kq4\"AØp\Ã∆†üG\√AÙ’°>¢Æ’π©†\'û™]≥,UUêëÖBBü\‘\÷VF6_U¥ç˚PR\·\—|WêïîáPBTRiÚ®Ñ#PíH\–\¬\„KunE|\Ã3(ç•È¢∂4úìg42∑∞#O0ãuY\“V∏œµ©v+ ÆOuí<&\Â\\«§íî1ŸïäH_	.R¥V(\‹\0Ec}j-æoM¡æˆÃ•í›±™m{Ù\«K!¢zeÇá\”]dñ\'F©^0ìL™ao\„\◊i)†3x§ï˙\»uî\Ôg™U˛üàÅÚõ<\n\·8á\"F8¸ˆ\«\ﬁh\‡ü\ﬂˆåäˇ\∆\"}A∏Rº l\\©\–BQUe\„òT˚!d\ZÉ>™\·4ni∞&eWñ\\≠∑Ü¢õØ\€\÷QgÛùÛBné°%q\€9PˇH:\‡\√1\…\ƒ÷ìü‘°Øe)·¢èÿè\‚	Z\ W°\‚ud\Î§E¬™[}ô\ÏD\Ëg≠,}\Ÿ1íHsá∆Äai*\ .\‹c©\Ó\¬SdÈñéEdíB+q\ÁsD#Ò-<E˘9TSåª9B)≈§™\Ïì\«s\‰nôI\÷¿Ê¥ôNSÿ∑∞æ\Èà=õ\‹\Á\Ój\«}°π¥\Èyøxïbv\‡`Ù#\Ì\Ë0\Ô_ƒÇ\ÿ|V\ƒ*˝{1`\Â˜Q2ï–∫‹î©ä7IfL%¿h\—\‡\Ó≥(m@õ\œ/1&\·ã≤\‘˚„©±n\ﬂB⁄üãT\Ã[5ΩS\\I˝Ñ,\Ô94l}D\√\“QJa∏¸¡XSLZ)|ú¨-*[õw\"†Ñû\√_§\»9Z\ÌM∫\ÔÙCñóò˜\ntñöì\À/ı\Ô˙ΩB˘VÄxƒê\”=I\»iëñ\Ô\Ë\«EñâSMIx\Œ~Z˛NQ˙4ˇs\0\Ì™ón¨@öN\'o¶o\'\Œ<‹¥x^R>ã8¶\ﬂ`KΩì8<B\Ô$Äøô\—\≈\’_[ î4ı	è\›\\7\„\√{]ÎÜ±f#ïPÃÉ˜ã\»èßì\Âeèùãﬁë\≈_9\◊	\Àc\Á¿˘∑Q∏∂0é\÷≈£˚D.bh˘ñ¡Üäg≠ÉG\À\–\ÓQ˝î¡{\∆`ÜTøb0É\·D\—n˚j°\0DZ£,ˇ}ì\0/\»õNT\·\È˜q⁄ä\ﬁ\›Bì kb\ÎˇQ\À#Cë8S1e\ŒT\Zóg26§≤ç9nM$3\∆¯©@EV0\ÈD∫†\œWä˝\0Lr\'5ÇTn?í©j.5û/\”Û\r\ÀG\ÀÙò∫uX\\\¬›å0;Ù^ı6\„\ÌÒéñS{\Œ\„¡µeOm\‰mz\nlº\ree\ÿmÜF\ÿt$Æ\r∑\’iGõrõ6VgO\ÁÑ&=#E&\–„ùç§ô¥\’!•Ã•\Õ8ô∞î\ÓGö\nMçáΩËõãˆú	\Ó\¬`K÷ÄvmQß\—_˘\ÁW\ŒE˙9\n ¡èù[HP¥1§\√w\Ÿ\Ÿs¥õ\À\—]Ëªì\Õ ∑\Ó¶™\nU™\¬MvQî\‹dép\’ç\÷E\rZ£±¸˘C2\Z≠Æ§‚Ñ±∑$P©˚\≈\„QZt\Í3êü\";\‚\—∑\ÃNT\„¸≠\r\√jµ°\Ëh\Ï\⁄@ç9å!êï\Ìzmml°Wtdsm0\…kù∏\„˙¨$°\¬3é\nÆ}ybE\Ãˆyˇ¬ã¯mIÜ[=óÙ§~\‚Ñ\"\r\ﬁaÉ˜´¡j5\—}Võx\"Ç5ï⁄Ñ\Î¨\÷\‚^¥jmq¿F≠≠àacM[Ä≤C4Qi-0ai;rÑbZ´•\¬¯\“:2Öﬁè»ü~™í{<\·r\ÏcáêJ9ù;£Û\ZÖ\Í\‹˜ëò	‚´≠~ebÙˆ§eò∂˛ê\—k≠-ã7lpZk\ÿ˚d\Ëæ#\“\Ó;\nmok\¬|êÄ≥E˙!\„\…\Ó+|,ócà;Ø(Ò\Âså	;ñ0∞Ml\"N{zÖ\÷\·\Ô\∆:SI¯lëΩàπ$C¶pcõÿéËäôè(áo\’\ÂêVg\÷˘£\À-\Î\◊˙f\—\Z\’\‚›é B#\'\‡ó@\r\’vhy$zS™pá;˛ÿµ#c∂2úÄ\ŸåP;4≥âﬁöéúŸî\‚–éå\◊ˆµ\«\⁄3ßIo≥d4\Í\Â%f\–LÜX¢áµ|\€0ß(ZlÒæÚt\‚ﬂ£K\≈Bì1\ÁÖ`§1IuN&Ûjiç…≠NhV\ﬂ\r\€“Éˆ\÷À∑ºâB\ÀT\—$Ò™®Rª´†£\”2\—x’ëy∫+≈£\ÿ2‚âº à\0π]Ω#Núlﬂàd.?ß\€+êÒ√¥â*kDù∞\¬&ã∏Rq|8∫b\Íà\¬\‘J•Û™\Ïˇ(Æ±#\‚n{]\›1+\ZOë9\⁄)™6å\ÂNºu\À<\Ì\’\nF∂\’]n\ÃZ\Î.Û¥\◊-\√8|`a\Ï_\ŒzHiä±ÇsN§ÚΩ˘e∫\÷\⁄%.AÑq\ÀGƒóŒí˘ªcõ\»Aiçâ\–\‚i\ƒv\–^A$\›VrpÖ6\«\Ôâ9!öì\"Ò\“Û¥-jzónD¿¸P\ÈcºkÖ(\ƒb pàdü(}\≈ŸµBõ2D!Æ.\Îèû\—v≤Ø)~ùÅ4X7\»\œN<\‚tVÁπàVquH§ZTea,Ç3◊áG∑92\¬DÔ≥ì\Ÿ\“îπë2\Í∫˛EtΩÀ∂ªvl\ÓC\‚ä6\€\ÍœÉìm>π\ﬁ\Ê˛õlt°≤wºé\ﬁ\ÔÇ–Ø\€}Œπ@†SliπÇ\∆2C,\Îß\Z\È*é$ÅJÚ’á\Ô[∞ŸÜ,Ωéñ.≤ôTodøè`\ÌzOçÕÉ§{ H≤üú\Ó:q7iâ—îá?!˚õ«üˇÇﬁÆ¿≥\“\0\0','6.1.3-40302');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-26 12:13:32
