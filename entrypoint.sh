#!/bin/sh
/app/dotnetAsp --urls http://127.0.0.1:5000 &
nginx -g "daemon off;"
