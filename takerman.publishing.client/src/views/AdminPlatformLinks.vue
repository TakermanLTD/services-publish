<template>
    <div class="row">
        <label>Selected platform
            <select class="form-select" v-model="selectedPlatform">
                <option v-for="(platform, index) in platforms" :key="index" :value="index">{{ platform }}</option>
            </select>
        </label>
    </div>
    <div class="row">
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>URL</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th></th>
                    <th>
                        <input type="text" v-model="this.new.name" class="form-control" />
                    </th>
                    <th>
                        <input type="url" v-model="this.new.url" class="form-control" />
                    </th>
                    <th>
                        <button @click="create" class="btn btn-success btn-sm"><i class="bi bi-plus-circle-fill"></i></button>
                    </th>
                </tr>
                <tr :id="'platformLink_' + link.id" v-for="(link, index) in platformLinks" :key="index">
                    <th>{{ link.id }}</th>
                    <th>
                        <input type="text" v-model="link.name" class="form-control" />
                    </th>
                    <th>
                        <input type="url" v-model="link.url" class="form-control" />
                    </th>
                    <th>
                        <button @click="save()" class="btn btn-success btn-sm"><i class="bi bi-floppy"></i></button>
                        <button @click="remove(link.id)" class="btn btn-danger btn-sm"><i class="bi bi-x-circle-fill"></i></button>
                    </th>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            selectedPlatform: 1,
            platforms: [],
            new: {
                name: '',
                url: ''
            },
            platformLinks: []
        }
    },
    methods: {
        async updateData() {
            this.platformLinks = await (await fetch('/PlatformLinks/GetAll?platform=' + this.selectedPlatform)).json();
        },
        async save() {
            this.platformLinks = await (await fetch('/PlatformLinks/Save', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(this.platformLinks)
            })).json();
            await this.updateData();
        },
        async create() {
            let result = await (await fetch('/PlatformLinks/Create', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    name: this.new.name,
                    url: this.new.url,
                    platform: Number(this.selectedPlatform)
                })
            })).json();
            this.platformLinks.push(result);
        },
        async remove(id) {
            if (await fetch('/PlatformLinks/Delete?id=' + id, { method: 'DELETE' })) {
                document.getElementById('platformLink_' + id).remove();
            }
        }
    },
    async mounted() {
        try {
            this.platforms = await (await fetch('/Home/GetEnum?enumName=Platform')).json();
            this.selectedPlatform = 1;
            await this.updateData();
        } catch (error) {
            console.log(error);
        }
    }
}
</script>