<template>
    <div>
        <form @submit.prevent="addSlabComanda">
            <input type="text" v-model="material" name = "material" placeholder="Material">
            <input type="text" v-model="lungime" name = "lungime" placeholder="Lungime">
            <input type="text" v-model="latime" name = "latime" placeholder="Latime">
            <input type="submit" value = "Adaugă" class="btn">
        </form>
    </div>
</template>

<script>

export default {
    name: "AddSlabComanda",
    data () {
        return {
            material: '',
            lungime: '',
            latime: ''
        }
    },
    methods: {
        addSlabComanda(e) {
            e.preventDefault();
            const SC = {
                
                material: this.material,
                lungime: this.lungime,
                latime: this.latime
            }
            // Send
            this.$emit('add-slabcomanda', SC);
            this.material = '';
            this.latime = '';
            this.lungime = '';

        }
    }
}
</script>

<style scoped>
    form {
        display: flex;
    }

    input[type="text"] {
        flex: 10;
        padding: 5px;
        
    }

    input[type="submit"]
    {
        flex: 2;
    }
    .btn {
        display: inline-block;
        border: none;
        background: #555;
        color: #fff;
        padding: 7px 20px;
        cursor: pointer;
    }
</style>
