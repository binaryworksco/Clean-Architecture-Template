@REM This script starts a tunnel using CloudFlare cloudflared tunnel and exposes the local DNS server on port 7020 to the internet.
@REM The tunnel is exposed on the subdomain ide.ads-sentry.com.
@REM Read the following article for more information on how to configure cloudflared - https://www.makeuseof.com/use-cloudflare-tunnel-expose-local-servers-internet/

@echo off
cloudflared tunnel run --url localhost:7020 <tunnel-id>