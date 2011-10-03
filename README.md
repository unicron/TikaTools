TikaTools is a small wrapper for [Apache Tika](http://tika.apache.org/) written in C#.

I wrote this while searching for a suitable way extract full-text before submitting documents to [Apache Solr](http://lucene.apache.org/solr/) using [SolrNet](http://code.google.com/p/solrnet/).  What I found was that there is nothing comparable to Tika for .Net!

I started this more as an experiment, mostly because I was using SolrNet 0.3x which had no support for the Solr [ExtractingRequestHandler](http://wiki.apache.org/solr/ExtractingRequestHandler).  Support for this has been added as of the 0.4.0.1001 alpha build, but it still seems incomplete.  ExtractingRequestHandler (aka Solr Cell) uses Tika as well, so the result should be very similar if not identical.

Note that others before me have gone a different route, using [IKVM](http://www.ikvm.net/), which basically provides a way to run Java code directly from .Net (crazy!).  Kevin Miller has one such example detailed out [here](http://blogs.dovetailsoftware.com/blogs/kmiller/archive/2010/07/02/using-the-tika-java-library-in-your-net-application-with-ikvm).  I like this approach as well, but wanted to provide my solution because it is much simpler and could be better for prototyping and the like.  It also doesn't have any extra dependencies besides the standalone Tika .jar.

Instructions:
1. Download this source
2. Download the runnable .jar version of [Tika](http://tika.apache.org/download.html/) and place in project root (same folder as TikaWrapper.cs)
3. ...
4. Profit!

Notes:
* Verified against Tika 0.9-0.10
* .Net 4.0/VS2010 but could probably be downgraded no problem
* Simple NUnit test included