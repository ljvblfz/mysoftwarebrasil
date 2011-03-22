ActiveRecordGenerator
by Roy Tate

This application was originally written to create the Castle ActiveRecord data classes for a project that I worked on over the summer of 2007.  While the end result is not as polished as I would like, it turned out to be very capable.  It can generate code in any language based on a database schema.  An NVelocity template is rendered with a table context containing all fields, primary keys, foreign keys, related tables and field names, etc.

This program requires a trusted connection to a Microsoft SQL Server 2000 or 2005 server.

The ASP_WebForm template is VERY new, and not ready for prime time, but the other templates have been used successfully on a number of occassions.
