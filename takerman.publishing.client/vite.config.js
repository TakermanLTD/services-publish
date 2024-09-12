import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';
// import 'owl.carousel/dist/assets/owl.carousel.css';
// import 'owl.carousel';
// import 'easing';

const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : "takerman.publishing.client";

if (!certificateName) {
    console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
    process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    if (0 !== child_process.spawnSync('dotnet', [
        'dev-certs',
        'https',
        '--export-path',
        certFilePath,
        '--format',
        'Pem',
        '--no-password',
    ], { stdio: 'inherit', }).status) {
        throw new Error("Could not create certificate.");
    }
}

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '^/Blog': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Picture': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/ProjectPlatforms': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Selling': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Blog': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Short': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Tweet': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Video': {
                target: 'https://localhost:7023/',
                secure: false
            },
            '^/Home': {
                target: 'https://localhost:7023/',
                secure: false
            }
        },
        port: 5175,
        https: {
            key: fs.readFileSync(keyFilePath),
            cert: fs.readFileSync(certFilePath),
        }
    }
})